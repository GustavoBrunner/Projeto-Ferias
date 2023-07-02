using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Main
{
    public class PrimitiveFactory 
    {
        public GameObject CreateCube(Vector3 scale, Transform parent)
        {
            var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.localScale = scale;
            cube.transform.SetParent(parent);
            return cube;
        }
    }
}
