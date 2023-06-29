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
        float _damage;
        ObservableHandler oHandler; //ObservableHandler instance
        private void Awake()
        {
            
        }
        private void Start()
        {
            oHandler = new ObservableHandler(PlayerController.Instance, this);
        }
        public void OnNotify<T>(NotificationType type, T value)
        {
            if (type == NotificationType.Damage)
            {
                _damage = float.Parse(value.ToString());
                Debug.Log(_damage);
            }
        }
    }
}
