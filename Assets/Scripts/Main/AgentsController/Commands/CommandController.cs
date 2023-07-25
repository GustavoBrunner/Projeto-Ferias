using UnityEngine;
namespace Main.AgentsController.Commands
{
    /// <summary>
    /// Um command controller, que ser� usado para intermediar a execu��o de todos os comandos. Deve ser instanciado
    /// na classe do player, onde passaremos todos os comandos, e aqui decidiremos como ele deve ou n�o ser executado.
    /// </summary>
    /// 
    
    public class CommandController
    {
        
        BaseCommand shootCommand;
        BaseCommand runCommand;
        BaseCommand jumpCommand;
        BaseCommand interactCommand;
        BaseCommand stopRun;
        BaseCommand aimCommand;
        public CommandController(BaseCommand shootCommand, BaseCommand runCommand, BaseCommand jumpCommand, BaseCommand interactCommand, BaseCommand stopRun, BaseCommand aimCommand)
        {
            this.shootCommand = shootCommand;
            this.runCommand = runCommand;
            this.jumpCommand = jumpCommand;
            this.interactCommand = interactCommand;
            this.stopRun = stopRun;
            this.aimCommand = aimCommand;
        }
        public void Shoot()
        {
            //Comando que far� o player atirar
            this.shootCommand?.Execute();
        }
        public void Run()
        {
            //Comando que far� o player correr
            this.runCommand?.Execute();
        }
        public void Jump()
        {
            //Comando que far� o player pular
            this.jumpCommand?.Execute();
        }
        public void Interact()
        {
            //Comando que far� o player interagir com um objeto.
            this.interactCommand?.Execute();
        }
        public void StopRun()
        {
            this.stopRun?.Execute();
        }
        public void AimCommand()
        {
            this.aimCommand?.Execute();
        }
    }
}
