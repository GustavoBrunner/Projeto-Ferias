using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Main.AgentsController.Observable;
namespace Main
{
    namespace AgentsController
    {
        
        [RequireComponent(typeof(Collider))]
        public abstract class BaseController : MonoBehaviour
        {
            [SerializeField]
            public List<IObserver> observers = new List<IObserver>();

            //protected List<IObserver> observers = new List<IObserver>();
            [SerializeField]
            protected NavMeshAgent Agent;

            protected Rigidbody rb;
            protected Transform tf;
            protected virtual void Awake()
            {
                rb = GetComponent<Rigidbody>();
                tf = GetComponent<Transform>();
                Agent = GetComponent<NavMeshAgent>();
            }
            protected virtual void Start()
            {
                
                Debug.Log(Agent);
            }
            public BaseController()
            {

            }
            protected abstract void NotifyObservers<T>(NotificationType type, T value);
            public abstract void AddObserver(IObserver observer);
            public abstract void AddObserver(IObserver[] observer);
            public abstract void RemoveObserver(IObserver observer);
        }
    }
}
