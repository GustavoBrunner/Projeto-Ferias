using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Main.AgentsController.Observable;
namespace Main
{
    namespace AgentsController
    {
        
        [RequireComponent(typeof(Collider))]
        public abstract class BaseController : MonoBehaviour
        {
            protected List<IObserver> observers = new List<IObserver>();

            protected Rigidbody rb;
            protected Transform tf;
            private void Awake()
            {
                rb = GetComponent<Rigidbody>();
                tf = GetComponent<Transform>();
            }
            public BaseController()
            {

            }
            protected abstract void NotifyObservers();
            public abstract void AddObserver(IObserver observer);
            public abstract void RemoveObserver(IObserver observer);
        }
    }
}
