// Exmple of Lyskov substitucion guideline implemented
// https://youtu.be/Z_ySH41NmUQ

// objects of a superclass should replaceble with objects of its subclasses and the program is still valid
// Reference variable of parent type can point to instances of different subtypes in the hierarchy
IEmployee contractorSteve = new ContractorEmployee{Name = "Steve"};
IEmployee fullTimeJosh = new FullTimeEmployee{Name = "Josh"};
IEmployee partTimeAlice = new PartTimeEmployee{Name = "Alice"};

List<IEmployee> employees = new List<IEmployee>{ contractorSteve, fullTimeJosh, partTimeAlice};

foreach (IEmployee employee in employees)
{
    Console.WriteLine($"{employee.Name} has a salary of {employee.GetSalary()} working {employee.GetHours()} hours");
}

// only part time and full time employees got bonus to salary
List<Employee> EmployeesWithBonus = new List<Employee>{new FullTimeEmployee{Name = "Mari"}, new PartTimeEmployee{Name = "Juri"}};

foreach (Employee employee in EmployeesWithBonus)
{
    Console.WriteLine($"{employee.Name} has a bonus of {employee.GetEmployeeBonus()}");
}

// only contract employees got comissions
ContractorEmployee contractorKyle = new ContractorEmployee{Name = "Kyle"};
Console.WriteLine($"{contractorKyle.Name} has a comission for {contractorKyle.GetContractComission()}");


// in this case of architecture IEmployee is base type of the hierarchy
abstract class Employee : IEmployee, IEmployeeBonus
{
    int _id;
    string _name = string.Empty;

    public int Id { get => _id; set => _id = value; }
    public string Name { get => _name; set => _name = value; }

    public abstract int GetSalary();
    public abstract int GetHours();

    public abstract decimal GetEmployeeBonus();

}


class ContractorEmployee : IEmployee, IContractComission
{
    private int _hours = 8;
    private int _Id;
    private string _Name = string.Empty;
    public int Id { get => _Id; set => _Id = value; }
    public string Name { get => _Name; set => _Name = value; }

    public decimal GetContractComission()
    {
        return _hours * 0.3M;
    }

    public int GetHours()
    {
        return _hours * 5;
    }

    public int GetSalary()
    {
        return _hours * 25; 
    }

}

class PartTimeEmployee : Employee, IEmployeeBonus
{
    private int _hours = 5;

    public override decimal GetEmployeeBonus()
    {
       return _hours * 0.3M;
    }

    public override int GetHours()
    {
        return _hours*3;
    }

    public override int GetSalary()
    {
        return _hours* 30; 
    }
}

class FullTimeEmployee : Employee, IEmployeeBonus
{
   private int _hours = 8;

    public override decimal GetEmployeeBonus()
    {
        return _hours * 0.5M;
    }

    public override int GetHours()
    {
        return _hours*5;
    }

    public override int GetSalary()
    {
        return _hours* 30; 
    }
}

// base type encapsulates everything common to hierarchy, and should not change
interface IEmployee
{
    public int Id { get; set; }
    public string Name { get; set; }

    public abstract int GetSalary();
    public abstract int GetHours();

    // not shared functionalities amongs different employee types
    // bonus calculator
    // contractor comissions calculator
}
interface IContractComission
{
    decimal GetContractComission();   
}

public interface IEmployeeBonus
{
    decimal GetEmployeeBonus();   
}