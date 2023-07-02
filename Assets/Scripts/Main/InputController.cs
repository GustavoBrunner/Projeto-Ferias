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
        
        BaseCommand _shootCommand;
        BaseCommand _runCommand;
        BaseCommand _jumpCommand;
        BaseCommand _interactCommand;
        BaseCommand _stopRun;
        CommandController _commandController;

        private static InputController _instance;
        public static InputController Instance { get { return _instance; } }

        private void Awake()
        {
            _instance = this;
        }
        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Mouse0))
                _commandController?.Shoot();
            if (Input.GetKeyDown(KeyCode.E))
                _commandController?.Interact();
            if (Input.GetKeyDown(KeyCode.LeftShift))
                _commandController?.Run();
            if(Input.GetKeyDown(KeyCode.Space))
                _commandController?.Jump();
            if(Input.GetKeyUp(KeyCode.LeftShift))
                _commandController?.StopRun();

        }
        public void StartCommands()
        {
            _shootCommand = new ShootCommand("Atirar", PlayerController.Instance.Shoot);
            _runCommand = new RunCommand("Correr", PlayerController.Instance.Run, PlayerController.Instance.StopRun);
            _jumpCommand = new JumpCommand("Pular", PlayerController.Instance.Jump);
            _interactCommand = new InteractCommand("Intera��o", PlayerController.Instance.Interact);
            _stopRun = new StopRunCommand("PararCorrida", PlayerController.Instance.StopRun);
            _commandController = new CommandController(_shootCommand, _runCommand, _jumpCommand, _interactCommand, _stopRun);
        }
    }
}
