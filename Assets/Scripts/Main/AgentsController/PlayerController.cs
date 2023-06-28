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
            /// Variáveis onde instanciaremos os comands, e commandcontroller.
            /// </summary>
            private ShootCommand shootCommand;
            private CommandController commandController;

            private void Awake()
            {
                //Instâncias do primeiro comando, passando o nome dele, e o método que ele executará
                shootCommand = new ShootCommand("Atirar", Shoot);
                //Instância do commandcontroller
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
            /// Função que será chamada pelo command controller e executará o tiro do personagem
            /// </summary>
            private void Shoot()
            {
                Debug.Log("pew pew pew Player atirando");
            }
        }
    }
}