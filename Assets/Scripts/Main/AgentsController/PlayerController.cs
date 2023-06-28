using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Main.AgentsController.Commands;
namespace Main
{
    namespace AgentsController
    {
        public class PlayerController : BaseController
        {
            /// <summary>
            /// Vari�veis onde instanciaremos os comands, e commandcontroller.
            /// </summary>
            private ShootCommand shootCommand;
            private CommandController commandController;

            private void Awake()
            {
                //Inst�ncias do primeiro comando, passando o nome dele, e o m�todo que ele executar�
                shootCommand = new ShootCommand("Atirar", Shoot);
                //Inst�ncia do commandcontroller
                commandController = new CommandController(shootCommand);
                gameObject.AddComponent<ShootCommand>();
            }

            private void Update()
            {
                if(Input.GetMouseButton(0))
                {
                    commandController.Shoot();
                }
            }
            /// <summary>
            /// Fun��o que ser� chamada pelo command controller e executar� o tiro do personagem
            /// </summary>
            private void Shoot()
            {
                Debug.Log("pew pew pew Player atirando");
            }
        }
    }
}