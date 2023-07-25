using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Main.AgentsController.Commands;
using Main.AgentsController;

namespace Main
{
    /// <summary>
    /// Input Controller que ir� definir os bot�es de todas as a��es que ser�o executadas
    /// pelo jogador. 
    /// Temos que instanciar os objetos do player, do command controller, e da a��o em si
    /// depois executamos cada comando que quisermos, separadamente.
    /// </summary>
    public class InputController : MonoBehaviour //n�o devemos instanciar usando a palavra new objetos monobehaviour, d� refer�ncia nula sempre :))
    {
        /// <summary>
        /// Vari�veis onde instanciaremos os comands, e commandcontroller.
        /// Tamb�m uma inst�ncia do player, para poder passar a fun��o dele para o input
        /// </summary>
        
        BaseCommand shootCommand;
        BaseCommand runCommand;
        BaseCommand jumpCommand;
        BaseCommand interactCommand;
        BaseCommand stopRun;
        BaseCommand aimCommand;
        CommandController commandController;

        private static InputController _instance;
        public static InputController Instance { get { return _instance; } }

        private void Awake()
        {
            _instance = this;
        }
        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Mouse0))
                commandController?.Shoot();
            if (Input.GetKeyDown(KeyCode.E))
                commandController?.Interact();
            if (Input.GetKeyDown(KeyCode.LeftShift))
                commandController?.Run();
            if(Input.GetKeyDown(KeyCode.Space))
                commandController?.Jump();
            if(Input.GetKeyUp(KeyCode.LeftShift))
                commandController?.StopRun();
            //if (Input.GetKeyDown(KeyCode.Mouse1))
            //    commandController?.AimCommand();

        }
        public void StartCommands()
        {
            shootCommand = new ShootCommand("Atirar", PlayerController.Instance.Shoot);
            runCommand = new RunCommand("Correr", PlayerController.Instance.Run, PlayerController.Instance.StopRun);
            jumpCommand = new JumpCommand("Pular", PlayerController.Instance.Jump);
            interactCommand = new InteractCommand("Intera��o", PlayerController.Instance.Interact);
            stopRun = new StopRunCommand("PararCorrida", PlayerController.Instance.StopRun);
            //aimCommand = new AimCommand("Mirar", PlayerController.Instance.Aim);
            commandController = new CommandController(shootCommand, runCommand, jumpCommand, interactCommand, stopRun, aimCommand);
        }
    }
}
