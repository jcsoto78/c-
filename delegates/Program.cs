// delegates need to get instatiated
myDelegate deleg = new myDelegate(MessagePrinter);

// calling the method over a delegate
deleg("HI There");

// another way of calling the method over a delegate
deleg.Invoke("Hi there from Invoke()");

// adding MessagePrinterAnother to invoke list
// events prevent anonymous subscriptions to this invocation list
deleg += MessagePrinterAnother;

// now calling the delegate executes 2 functions 
deleg.Invoke("Make me a millionaire now");


void MessagePrinter(string message){
    Console.WriteLine($"Message is: {message}");
}

void MessagePrinterAnother(string message){
    Console.WriteLine($"Another Message is: {message}");
}

// shortcut to instatiation
numericDelegate numericDeleg =  doubleNumber;
numericDeleg += tripleNumber;

numericDeleg(5);

decimal doubleNumber (int a){
    decimal number = a*a;
    Console.WriteLine($"double number is: {number}");
    return number;
}

decimal tripleNumber (int a){
    decimal number = a*a*a;
    Console.WriteLine($"Triple number is: {number}");
    return number;
} 

// a delegate is c# way for callbacks in js
delegate void myDelegate(string message);

delegate decimal numericDelegate(int a);
// numericDelegate numericDeleg = numericDelegate()


