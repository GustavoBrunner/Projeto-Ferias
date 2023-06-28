namespace Main.AgentsController.Commands
{
    /// <summary>
    /// Criamos uma classe base para os comandos, que será abstrata, para não ser usada como componente
    /// e terá um método abstrato também, para ser sobrescrito depois.
    /// </summary>
    public abstract class BaseCommand 
    {
        
        protected BaseCommand() { }
        public abstract void Execute();
        
    }
}
