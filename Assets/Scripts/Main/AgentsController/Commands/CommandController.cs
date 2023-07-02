using UnityEngine;
namespace Main.AgentsController.Commands
{
    /// <summary>
    /// Um command controller, que ser� usado para intermediar a execu��o de todos os comandos. Deve ser instanciado
    /// na classe do player, onde passaremos todos os comandos, e aqui decidiremos como ele deve ou n�o ser executado.
    /// </summary>
    /// 
    
    public class CommandController : MonoBehaviour
    {
        
        BaseCommand _shootCommand;
        BaseCommand _runCommand;
        BaseCommand _jumpCommand;
        BaseCommand _interactCommand;
        BaseCommand _stopRun;
        public CommandController(BaseCommand shootCommand, BaseCommand runCommand, BaseCommand jumpCommand, BaseCommand interactCommand, BaseCommand stopRun)
        {
            this._shootCommand = shootCommand;
            this._runCommand = runCommand;
            this._jumpCommand = jumpCommand;
            this._interactCommand = interactCommand;
            this._stopRun = stopRun;
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
        public void StopRun()
        {
            _stopRun.Execute();
        }
    }
}
