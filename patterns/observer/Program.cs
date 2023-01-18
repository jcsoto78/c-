// observer is about object comunication
// Some objects may need to do something when another object's memmory changes
// lets implement a sinple case of observer or pub-sub pattern
// https://www.youtube.com/watch?v=oVAFvyICmbw

Player Marksus = new Player{playerName = "Marksus Fighter"};
Player Jinna = new Player{playerName = "Jinna Wizard"};

NpcManager creatureGenerator = new NpcManager();

// Marksus is now observing NpcManager
creatureGenerator.Attach(Marksus);
creatureGenerator.Attach(Jinna);

// spawn a goblin
creatureGenerator.npc = Npcs.Goblin;
//  spawn a dragon
creatureGenerator.npc = Npcs.Dragon;


// lets create the actual classes for latter interfaces
// lets say there is a game manager is notifying players a new monster has appeared

class NpcManager : IPublisher
{
    private Npcs _npc;

    public Npcs npc { 
        get => _npc; 
        set {
            _npc = value;
            Notify(); // notifies subscribers everytime _npc memory changes
        } 
    }

    private delegate void _subscribersDeleg(IPublisher publisher);

    private _subscribersDeleg? subscribersDeleg;


    public void Attach(IObserver subscriber)
    {
        // attach observer object to subscribersDeleg
        subscribersDeleg += subscriber.Update;
    }

    public void Notify()
    {
        // if (subscribersDeleg != null)
        subscribersDeleg?.Invoke(this);
    }
}

class Player : IObserver {

    private string _playerName = string.Empty;
    public string? playerName { get; set; }

    public void Update(IPublisher publisher)
    {       
        if (publisher is NpcManager)
            Console.WriteLine($"{playerName} sees a {publisher.npc}");
    }
}



interface IPublisher {

    // adds an observer to the list of subscribers
    void Attach(IObserver subscriber);

    // this methods will notify all subscribers when this object changes
    void Notify();

    Npcs npc
    {
        get;
        set;
    }
}

interface IObserver {
    // the method to execute by Notify() in the Publisher
    void Update(IPublisher publisher);
}

enum Npcs {
    Medusa = 1,
    Goblin = 2,
    Peasant = 3,
    Dragon = 4
}