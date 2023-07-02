using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Main.AgentsController.Observable;

namespace Main.AgentsController
{
    public class EnemyController : BaseController, IObserver
    {
        protected override void Start()
        {
            base.Start();
            gameObject.tag = "Enemy";
        }
        public override void AddObserver(IObserver observer)
        {
            throw new System.NotImplementedException();
        }

        public override void AddObserver(IObserver[] observer)
        {
            throw new System.NotImplementedException();
        }

        public override void RemoveObserver(IObserver observer)
        {
            throw new System.NotImplementedException();
        }

        protected override void NotifyObservers<T>(NotificationType type, T value)
        {
            throw new System.NotImplementedException();
        }

        private void Awake()
        {
        }
        private void Update()
        {
        }

        public void OnNotify<T>(NotificationType type, T value)
        {
            if(type == NotificationType.positionChange)
            {
                Debug.Log($"Player changing his position, current in {value}");
            }
        }
    }
}
