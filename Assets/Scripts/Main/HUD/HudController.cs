using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Main.AgentsController.Observable;
using Main.AgentsController;
namespace Main
{
    public class HudController : MonoBehaviour, IObserver
    {
        PlayerController playerController;
        float damage;
        private void Awake()
        {
            playerController = new PlayerController();
            
        }
        private void Start()
        {
            playerController.AddObserver(this);
        }
        public void OnNotify<T>(NotificationType type, T value)
        {
            Debug.Log("Tentando notificar");
            if (type == NotificationType.Damage)
                if (value.Equals(typeof(float)))
                {
                    damage = float.Parse("value");
                    Debug.Log(damage);
                }
            
        }
    }
}
