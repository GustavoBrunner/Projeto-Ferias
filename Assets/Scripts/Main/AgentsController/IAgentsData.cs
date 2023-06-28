namespace Main.AgentsController
{
    public interface IAgentsData
    {
        string Name { get; protected set; }
        float Hp { get; protected set; }
        float Damage { get; protected set; }
        bool CanMove { get; protected set; }
        float Speed { get; protected set; }

        void TakeDamage();
    

    }
}
