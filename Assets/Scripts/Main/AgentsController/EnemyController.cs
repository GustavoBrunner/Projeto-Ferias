using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Main.AgentsController.Observable;

namespace Main.AgentsController
{
    public class EnemyController : BaseController
    {
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

        protected override void NotifyObservers()
        {
            throw new System.NotImplementedException();
        }

        private void Awake()
        {
        }
        private void Update()
        {
        }
    }
}
