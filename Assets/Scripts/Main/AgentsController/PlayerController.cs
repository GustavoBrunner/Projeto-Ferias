using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Main.AgentsController.Commands;
using Main.AgentsController.Observable;
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
            /// Fun��o que ser� chamada pelo command controller e executar� o tiro do personagem
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

            protected override void NotifyObservers()
            {
                foreach (var observer in this.observers)
                {
                    observer.OnNotify(NotificationType.Damage, 20f);
                    //N�o est� entrando no loop, esse � o problema que t� dando.
                }
            }

            public override void AddObserver(IObserver observer)
            {
                this.observers.Add(observer);
                Debug.Log(this.observers.Count);
            }

            public override void RemoveObserver(IObserver observer)
            {
                throw new NotImplementedException();
            }
            private void Update()
            {
                if (Input.GetKeyDown(KeyCode.Space))
                    TakeDamage();
            }
            public void TakeDamage()
            {
                NotifyObservers();
            }
            
        }
    }
}