using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Main.AgentsController;
namespace Main
{
    public class GameController : MonoBehaviour
    {
        private Dictionary<string, GameObject> _prefabs = new Dictionary<string, GameObject>();

        private void Awake()
        {
            _prefabs.Add("Player", Resources.Load<GameObject>("Prefabs/Player"));
            Instantiate(_prefabs["Player"], Vector3.zero, Quaternion.identity);
        }

        void Update()
        {

        }


        private void CreateWorld()
        {

        }
    }
}
