namespace Main.AgentsController.Commands
{
    /// <summary>
    /// Um command controller, que será usado para intermediar a execução de todos os comandos. Deve ser instanciado
    /// na classe do player, onde passaremos todos os comandos, e aqui decidiremos como ele deve ou não ser executado.
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
            //Comando que fará o player atirar
            _shootCommand.Execute();
        }
        public void Run()
        {
            //Comando que fará o player correr
            _runCommand.Execute();
        }
        public void Jump()
        {
            //Comando que fará o player pular
            _jumpCommand.Execute();
        }
        public void Interact()
        {
            //Comando que fará o player interagir com um objeto.
            _interactCommand.Execute();
        }
    }
}
