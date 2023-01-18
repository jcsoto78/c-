// lets write a strategy example for rpg npc actions
// depeding of npc job it should take some action
//check https://www.youtube.com/watch?v=VZaRNu8rPIU
//strategy is about switch behaviour over recieved parameters at run time

new CombatActionManager{NpcClass= NpcJob.Fighter}.ActionCombat();
new CombatActionManager{NpcClass= NpcJob.Wizard}.ActionCombat();

interface INpcCombatAction
{
    void npcAttackAction();
}

enum NpcJob
{
    Fighter = 0,
    Wizard = 1
}

class CombatActionManager
{
    private NpcJob _npcClass;

    internal NpcJob NpcClass { get => _npcClass; set => _npcClass = value; }

    internal void ActionCombat () {
        switch (_npcClass)
        {
            case NpcJob.Fighter:
                new Fighter().npcAttackAction(); 
                break; 
            case NpcJob.Wizard: 
                new Wizard().npcAttackAction(); 
                break; 
        }
    }
}


class Fighter : INpcCombatAction
{
    public void npcAttackAction()
    {
        Console.WriteLine("Figther Girl Attacks with Axe");
    }
}

class Wizard : INpcCombatAction
{
    public void npcAttackAction()
    {
        Console.WriteLine("Sexy witch casts fire ball");
    }
}



