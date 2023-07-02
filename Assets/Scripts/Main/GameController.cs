using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using Main.AgentsController;
using Main.AgentsController.Observable;
using Main.FSM;
using System.Linq;
using System;
using Main.DTO;

namespace Main
{
    public class GameController : MonoBehaviour, IObserver
    {
        public static GameController Instance { get; private set; }

        private Dictionary<string, GameObject> _prefabs = new Dictionary<string, GameObject>();
        ObservableHandler _oHandler;
        List<EnemyController> enemyControllers = new List<EnemyController>();
        Camera _camera;
        HudController _hudController;
        GameObject _blockParent;
        WorldCreationDTO _worldDTO;
        public bool isInTestPeriod { get; private set; }
        private PrimitiveFactory _primitives;
        private FSMPhases _phaseControl;
        private void Awake()
        {
            isInTestPeriod = true;
            _primitives = new PrimitiveFactory();
            _prefabs.Add("Player", Resources.Load<GameObject>("Prefabs/Player"));
            _prefabs.Add("Enemie1", Resources.Load<GameObject>("Prefabs/Enemie"));
            gameObject.AddComponent<FSMPhases>();
            CreateSingleton();
            GetReferences();
            CreatePhases();
            
        }
        private void Start()
        {
            NoTestCreateWorld();
        }
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.F1))
            {
                TurnFSMon(GamePhases.first);
                
                Debug.Log("Criando mundo");
            }
            if(Input.GetKeyDown(KeyCode.Keypad1))
            {
                SceneManager.LoadScene("FirstPhase");
                _worldDTO = UpdateDTO(GamePhases.first);
            }
            if(Input.GetKeyDown(KeyCode.Keypad2))
            {
                _worldDTO = UpdateDTO(GamePhases.second);
            }
        }
        private void CreateEnemies()
        {
            var inimigo = Instantiate(_prefabs["Enemie1"], Vector3.zero, Quaternion.identity);
            enemyControllers.Add(inimigo.GetComponent<EnemyController>());
            Debug.Log(enemyControllers.Count);
            _oHandler.AddObservers(inimigo.GetComponent<IObserver>());
        }
        public Ray GetMousePos()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            return ray;
        }
        private void GetReferences()
        {
            try
            {
                _blockParent = GameObject.FindGameObjectWithTag("BlockParent");
                _phaseControl = FindAnyObjectByType<FSMPhases>();
                _hudController = FindAnyObjectByType<HudController>();
                _worldDTO = Resources.Load<WorldCreationDTO>("DTOs/WorldCreationDTO");
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
            }
        }
        //Create the base of the game based on the actual game phase. Testing purpose.
        public void ChangeCreationOnPhase(GamePhases phase)
        {
            if(isInTestPeriod)
            {
                switch(phase)
                {
                    case GamePhases.none:
                        Debug.Break();
                        break;
                    case GamePhases.first:
                        //CreateBaseWorld();
                        
                        CreatePlayer();
                        HudController.Instance.GetData();
                        InputController.Instance.StartCommands();
                        PlayerController.Instance.FirstPhasePlayer(_worldDTO);
                        break;
                    case GamePhases.second:

                        break;
                    case GamePhases.third:

                        break;

                    default:
                        break;
                }
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
                DestroyImmediate(Instance);
                Instance = this;
            }
        }
        //Create the terrain
        void CreateBaseWorld()
        {
            var floor = _primitives.CreateCube(_worldDTO.PlatformSize, _blockParent.transform);
            floor.name = "Floor";
        }
        //Create the blocking of the first phase
        //Later can be replaces with a scene
        void CreatePlayer()
        {
            Instantiate(_prefabs["Player"], Vector3.zero, Quaternion.identity);
            _oHandler = new ObservableHandler(PlayerController.Instance, HudController.Instance);
            _oHandler.AddObservers(this);
        }
        //Create Phases
        void CreatePhases()
        {
            IPhase phase;
            phase = new FirstPhase(_phaseControl.ChangePhase);
            _phaseControl.AddPhases(phase);
        }
        //Observers notification
        public void OnNotify<T>(NotificationType type, T value)
        {
            Debug.Log("Notificando GameController");
        }
        //Turn the finit state machine on
        void TurnFSMon(GamePhases phase)
        {
            _phaseControl.StartFSM(phase);
        }
        //Update the DTO based on the Game Phase, the data will be used to create the world
        private WorldCreationDTO UpdateDTO(GamePhases phase)
        {
            switch (phase)
            {
                case GamePhases.none:
                    Debug.Break();
                    break;
                case GamePhases.first:
                    _worldDTO.Hp = 0f;
                    _worldDTO.name = "Ciclaninho";
                    _worldDTO.Stamina = 20f;
                    _worldDTO.Position = new Vector3(0, 1, 0);
                    _worldDTO.Speed = 10f;
                    Debug.Log($"DTO atualizado: {_worldDTO.Hp.ToString()}, {_worldDTO.Position.ToString()}, {_worldDTO.Stamina.ToString()}, {_worldDTO.Speed.ToString()}, {_worldDTO.name}");
                    break;
                case GamePhases.second:
                    _worldDTO.Hp = 10f;
                    _worldDTO.name = "Fulaninho";
                    _worldDTO.Stamina = 100f;
                    _worldDTO.Position = new Vector3(10, 1, 0);
                    _worldDTO.Speed = 5f;
                    Debug.Log($"DTO atualizado: {_worldDTO.Hp.ToString()}, {_worldDTO.Position.ToString()}, {_worldDTO.Stamina.ToString()}, {_worldDTO.Speed.ToString()}, {_worldDTO.name}");
                    break;
                case GamePhases.third:

                    break;
                default:
                    break;
            }
            return _worldDTO;
        }
        void NoTestCreateWorld()
        {
            if (!isInTestPeriod)
            {
                SceneManager.LoadScene("FirstPhase");
                _worldDTO = UpdateDTO(GamePhases.first);
                TurnFSMon(GamePhases.first);
            }
        }
    }
}
