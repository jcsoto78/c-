
using System.Text.Json;

var person = new Person{Name= "Gauchito", Title = "Professional"};
var car = new Car{Make= "BMW M4", Cost= 40000};

new ObjPrinter<Person>(person);
new ObjPrinter<Car>(car);

public class Person
{
    private string? _Title;
    public string? Name { get; set; }
    public string Title 
    { 
        get => _Title?? string.Empty;
        set { _Title = value; }
    }
}

class Car
{
    public string? Make { get; set; }
    public int Cost { get; set; }
}

public class ObjPrinter<T> {
    private readonly T _Data;

    public ObjPrinter(T data)
    {
        _Data = data;
        DataPrinter();
    }

    public void DataPrinter() {
        string jsonString = JsonSerializer.Serialize(_Data);
        Console.WriteLine(jsonString);
    } 
}
