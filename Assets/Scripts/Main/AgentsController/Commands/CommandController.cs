namespace Main.AgentsController.Commands
{
    /// <summary>
    /// Um command controller, que ser� usado para intermediar a execu��o de todos os comandos. Deve ser instanciado
    /// na classe do player, onde passaremos todos os comandos, e aqui decidiremos como ele deve ou n�o ser executado.
    /// </summary>
    public class CommandController 
    {
        BaseCommand shootCommand;  
    
        public CommandController(BaseCommand shootCommand)
        {
            this.shootCommand = shootCommand;
        }
        

        public void Shoot()
        {
            shootCommand.Execute();
        }
    }
}
