namespace Main.AgentsController.Commands
{
    /// <summary>
    /// Um command controller, que ser� usado para intermediar a execu��o de todos os comandos. Deve ser instanciado
    /// na classe do player, onde passaremos todos os comandos, e aqui decidiremos como ele deve ou n�o ser executado.
    /// </summary>
    /// 
    
    public class CommandController 
    {
        
        BaseCommand _shootCommand;
        BaseCommand _runCommand;
        BaseCommand _jumpCommand;
        BaseCommand _interactCommand;
    
        public CommandController(BaseCommand shootCommand, BaseCommand runCommand, BaseCommand jumpCommand, BaseCommand interactCommand)
        {
            this._shootCommand = shootCommand;
            this._runCommand = runCommand;
            this._jumpCommand = jumpCommand;
            this._interactCommand = interactCommand;
        }
        

        public void Shoot()
        {
            //Comando que far� o player atirar
            _shootCommand.Execute();
        }
        public void Run()
        {
            //Comando que far� o player correr
            _runCommand.Execute();
        }
        public void Jump()
        {
            //Comando que far� o player pular
            _jumpCommand.Execute();
        }
        public void Interact()
        {
            //Comando que far� o player interagir com um objeto.
            _interactCommand.Execute();
        }
    }
}
