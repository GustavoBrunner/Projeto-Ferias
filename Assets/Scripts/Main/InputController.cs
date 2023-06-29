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
    public class InputController : MonoBehaviour
    {
        /// <summary>
        /// Vari�veis onde instanciaremos os comands, e commandcontroller.
        /// Tamb�m uma inst�ncia do player, para poder passar a fun��o dele para o input
        /// </summary>
        PlayerController _playerController;
        BaseCommand _shootCommand;
        BaseCommand _runCommand;
        BaseCommand _jumpCommand;
        BaseCommand _interactCommand;
        CommandController _commandController;
        private void Start()
        {
            _playerController = new PlayerController();
            _shootCommand = new ShootCommand("Atirar", _playerController.Shoot);
            _runCommand = new RunCommand("Correr", _playerController.Run);
            _jumpCommand = new JumpCommand("Pular", _playerController.Jump);
            _interactCommand = new InteractCommand("Intera��o", _playerController.Interact);
            _commandController = new CommandController(_shootCommand, _runCommand, _jumpCommand, _interactCommand);
        }
        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Mouse0))
                _commandController.Shoot();
            if (Input.GetKeyDown(KeyCode.E))
                _commandController.Interact();
            if (Input.GetKeyDown(KeyCode.LeftShift))
                _commandController.Run();
            if(Input.GetKeyDown(KeyCode.Space))
                _commandController.Jump();
        }
    }
}
