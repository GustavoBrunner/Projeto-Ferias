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
            private bool _isRunning;
            Vector3 _mousePosition;
            private WorldCreationDTO _firstDto;
            protected override void Awake()
            {
                CreateSingleton();
                base.Awake();
                //FirstPhasePlayer();
                _firstDto = Resources.Load<WorldCreationDTO>("DTOs/PlayerDTO");
            }
            protected override void Start()
            {
                base.Start();
            }
            private void Update()
            {
                _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Move();
                }
                if (_isRunning && Agent.velocity.magnitude > 0)
                {
                    Stamina -= Time.deltaTime;
                    NotifyObservers(NotificationType.stamina, Stamina);
                }
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
                _isRunning = true;
                Debug.Log("Player Running");
                if (Stamina > 0)
                    Agent.speed = 10f;
                else
                    Agent.speed = 5f;
            }
            public void StopRun()
            {
                _isRunning = false;
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
                foreach (var observer in this.observers)
                {
                    observer?.OnNotify(type, value);
                }
            }

            public override void AddObserver(IObserver observer)
            {
                this.observers?.Add(observer);
                Debug.Log(this.observers.Count);
                
            }

            public override void AddObserver(IObserver[] observer)
            {
                this.observers?.AddRange(observer);
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
                    Agent.speed = dto.Speed;
                    this.Stamina = dto.Stamina;
                    Debug.Log("Criando player");
                }
            }
        }
    }
}