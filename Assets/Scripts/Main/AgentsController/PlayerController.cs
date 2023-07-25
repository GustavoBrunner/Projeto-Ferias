using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Main.AgentsController.Commands;
using Main.AgentsController.Observable;
using Main.DTO;
using UnityEngine.AI;
namespace Main
{
    namespace AgentsController
    {
        public class PlayerController : BaseController
        {
            public static PlayerController Instance { get; private set; }

            public float Stamina { get; private set; }
            private bool isRunning;
            Vector3 mousePosition;
            private WorldCreationDTO firstDto;
            public const float MIN_STAMINA = 0f;
            public const float MAX_STAMINA = 20f;
            //private float aimSpeed;
            //private bool canAim;
            //private bool isAim;
            protected override void Awake()
            {
                CreateSingleton();
                base.Awake();
                //FirstPhasePlayer();
                firstDto = Resources.Load<WorldCreationDTO>("DTOs/PlayerDTO");
                //canAim = true;
                //isAim = false;
            }
            protected override void Start()
            {
                base.Start();
            }
            private void Update()
            {
                mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Move();
                }
                SubStamina();
            }
            private void CreateSingleton()
            {
                if (Instance == null)
                {
                    Instance = this;
                }
                else
                {
                    DestroyImmediate(gameObject);
                    Instance = this;
                }
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
                isRunning = true;
                Debug.Log("Player Running");
                if (Stamina > MIN_STAMINA)
                    Agent.speed = 10f;
                
            }
            private void SubStamina()
            {
                if (isRunning && Agent.velocity.magnitude > 0)
                {
                    if (Stamina > MIN_STAMINA)
                    {
                        Stamina -= Time.deltaTime;
                        NotifyObservers(NotificationType.stamina, Stamina);
                    }
                }
            }
            public void StopRun()
            {
                isRunning = false;
                Agent.speed = 5f;
            }
            public void Jump()
            {
                Debug.Log("Player Jumping");
            }
            public void Interact()
            {
                Debug.Log("Player Interacting");
            }

            protected override void NotifyObservers<T>(NotificationType type, T value)
            {
                Debug.Log("Notificando observadores");
                foreach (var observer in this.Observers)
                {
                    observer?.OnNotify(type, value);
                }
            }

            public override void AddObserver(IObserver observer)
            {
                this.Observers?.Add(observer);
                Debug.Log(this.Observers.Count);
                
            }

            public override void AddObserver(IObserver[] observer)
            {
                this.Observers?.AddRange(observer);
            }
            public override void RemoveObserver(IObserver observer)
            {
                throw new NotImplementedException();
            }
            
            public void TakeDamage()
            {
                NotifyObservers(NotificationType.damage, 10f);
            }
            public void Move()
            {
                RaycastHit hit;
                if(Physics.Raycast(GameController.Instance.GetMousePos(), out hit))
                {
                    Agent?.SetDestination(hit.point);
                }
                NotifyObservers(NotificationType.positionChange, Vector3.zero);
                //Agent?.MovePosition(_mousePosition);
            }
            public void FirstPhasePlayer( WorldCreationDTO dto)
            {
                if (GameController.Instance.isInTestPeriod)
                {
                    this.transform.position = dto.Position;
                    this.Agent.speed = dto.Speed;
                    this.Stamina = dto.Stamina;
                    Debug.Log("Criando player");
                }
            }
        }
    }
}