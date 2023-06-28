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
            public static PlayerController Instance { get; private set; }

            private void Awake()
            {
                Instance = this;
            }
            /// <summary>
            /// Função que será chamada pelo command controller e executará o tiro do personagem
            /// </summary>
            public void Shoot()
            {
                Debug.Log("pew pew pew Player atirando");
            }

            public void Run()
            {
                Debug.Log("Player Running");
            }
            public void Jump()
            {
                Debug.Log("Player Jumping");
            }
            public void Interact()
            {
                Debug.Log("Player Interacting");
            }
        }
    }
}