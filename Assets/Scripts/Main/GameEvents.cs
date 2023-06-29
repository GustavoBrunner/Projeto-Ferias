using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace Main.AgentsController
{
    public class PropertieEvent<T> : UnityEvent<T> { }

    public class GameEvents<T> 
    {
        public static PropertieEvent<T> onPropertieEvent = new PropertieEvent<T>(); 
    }
}
