using Main.AgentsController.Observable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Main
{
    namespace AgentsController
    {
        
        [RequireComponent(typeof(Collider))]
        public abstract class BaseController : MonoBehaviour
        {
            

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
        }
    }
}
