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
using System.Threading.Tasks;

namespace Main
{
    public class GameController : MonoBehaviour, IObserver
    {
        public static GameController Instance { get; private set; }

        private Dictionary<string, GameObject> prefabs = new Dictionary<string, GameObject>();
        ObservableHandler oHandler;
        List<EnemyController> enemyControllers = new List<EnemyController>();
        Camera camera;
        HudController hudController;
        GameObject blockParent;
        WorldCreationDTO worldDTO;
        public bool isInTestPeriod { get; private set; }
        private PrimitiveFactory primitives;
        private FSMPhases phaseControl;
        private void Awake()
        {
            isInTestPeriod = true;
            primitives = new PrimitiveFactory();
            prefabs.Add("Player", Resources.Load<GameObject>("Prefabs/Player"));
            prefabs.Add("Enemie1", Resources.Load<GameObject>("Prefabs/Enemie"));
            gameObject.AddComponent<FSMPhases>();
            CreateSingleton();
            GetReferences();
            CreatePhases();
            
        }
        private void Start()
        {
        }
        void Update()
        {
            //se estiver em período de testes, essas teclas poderão ser usadas para alterar as cenas, para futuros testes
            if (isInTestPeriod)
            {
                if(Input.GetKeyDown(KeyCode.F1))
                {
                    TurnFSMon(GamePhases.first);
                    Debug.Log("Criando mundo");
                }
                if(Input.GetKeyDown(KeyCode.Keypad1))
                {
                    SceneManager.LoadScene("SecondPhase");
                    TurnFSMon(GamePhases.second);
                }
                if(Input.GetKeyDown(KeyCode.Keypad2))
                {
                    worldDTO = UpdateDTO(GamePhases.second);
                }
                if(Input.GetKeyDown(KeyCode.Alpha1))
                {
                    LoadScene(GamePhases.first);
                }
                if (Input.GetKeyDown(KeyCode.Keypad0))
                {
                    LoadScene(GamePhases.test);
                }
            }
        }
        //cria os inimigos, e já adiciona eles aos observadores do player
        private void CreateEnemies()
        {
            var inimigo = Instantiate(prefabs["Enemie1"], Vector3.zero, Quaternion.identity);
            enemyControllers.Add(inimigo.GetComponent<EnemyController>());
            Debug.Log(enemyControllers.Count);
            oHandler.AddObservers(inimigo.GetComponent<IObserver>());
        }
        //pega a posição do mapa em relação à tela para o mundo
        public Ray GetMousePos()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            return ray;
        }
        //Pega todas as referências necessárias para o jogo acontecer normalmente
        private void GetReferences()
        {
            try
            {
                blockParent = GameObject.FindGameObjectWithTag("BlockParent");
                phaseControl = FindAnyObjectByType<FSMPhases>();
                hudController = FindAnyObjectByType<HudController>();
                worldDTO = Resources.Load<WorldCreationDTO>("DTOs/WorldCreationDTO");
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
            }
        }

        //usar async num método nos permite que as coisas sejam executadas de maneira assíncronas
        //e também que possamos esperar até que algo seja executado, para podermos continuar as execuções posteriores
        public async void ChangeCreationOnPhase(GamePhases phase)
        {
            switch (phase)
            {
                case GamePhases.none:
                    Debug.Break();
                    break;
                case GamePhases.first:
                    //CreateBaseWorld();
                    Debug.Log("Creating first phase");
                    worldDTO = UpdateDTO(GamePhases.second);
                    Debug.Log("DTO updated");
                    Debug.Log("Player Created");
                    CreatePlayer();
                    Debug.Log("Player data updated");
                    PlayerController.Instance.FirstPhasePlayer(worldDTO);
                    Debug.Log("Data collected");
                    HudController.Instance.GetData();
                    InputController.Instance.StartCommands();
                    break;
                case GamePhases.second:

                    break;
                case GamePhases.third:

                    break;

                default:
                    break;
            }
        }
        //cria o singleton do game controller
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
            var floor = primitives.CreateCube(worldDTO.PlatformSize, blockParent.transform);
            floor.name = "Floor";
        }
        //Create the blocking of the first phase
        //Later can be replaces with a scene
        void CreatePlayer()
        {
            Instantiate(prefabs["Player"], worldDTO.Position, Quaternion.identity);
            oHandler = new ObservableHandler(PlayerController.Instance, HudController.Instance);
            oHandler.AddObservers(this);
        }
        //Create Phases
        void CreatePhases()
        {
            IPhase phase;
            phase = new FirstPhase(phaseControl.ChangePhase);
            phaseControl.AddPhases(phase);
        }
        //Observers notification
        public void OnNotify<T>(NotificationType type, T value)
        {
            Debug.Log("Notificando GameController");
        }
        //Turn the finit state machine on
        void TurnFSMon(GamePhases phase)
        {
            phaseControl.StartFSM(phase);
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
                    worldDTO.Hp = 0f;
                    worldDTO.name = "Ciclaninho";
                    worldDTO.Stamina = 10f;
                    worldDTO.Position = new Vector3(0, 1, 0);
                    worldDTO.Speed = 10f;
                    worldDTO.AimSpeed = 3f;
                    Debug.Log($"DTO atualizado: {worldDTO.Hp.ToString()}, {worldDTO.Position.ToString()}, {worldDTO.Stamina.ToString()}, {worldDTO.Speed.ToString()}, {worldDTO.name}");
                    break;
                case GamePhases.second:
                    worldDTO.Hp = 10f;
                    worldDTO.name = "Fulaninho";
                    worldDTO.Stamina = 20f;
                    worldDTO.Position = new Vector3(10, 1, 0);
                    worldDTO.Speed = 5f;
                    worldDTO.AimSpeed = 5f;
                    Debug.Log($"DTO atualizado: {worldDTO.Hp.ToString()}, {worldDTO.Position.ToString()}, {worldDTO.Stamina.ToString()}, {worldDTO.Speed.ToString()}, {worldDTO.name}");
                    break;
                case GamePhases.third:

                    break;
                default:
                    break;
            }
            return worldDTO;
        }
        void LoadScene(GamePhases phases)
        {
            switch(phases)
            {
                case GamePhases.none:
                    break;
                case GamePhases.test:
                    SceneManager.LoadSceneAsync("TestScreen");
                    break;
                case GamePhases.first:
                    SceneManager.LoadSceneAsync("FirstPhase");
                    break;
                case GamePhases.second:
                    SceneManager.LoadSceneAsync("SecondPhase");
                    break;
                case GamePhases.third:
                    SceneManager.LoadSceneAsync("ThirdPhase");
                    break;
                default:
                    break;
            }
        }
    }
}
