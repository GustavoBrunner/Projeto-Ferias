using UnityEngine;

namespace Main.DTO
{
    [CreateAssetMenu(fileName =("WorldCreationDTO"), menuName = "DTO" )]
    public class WorldCreationDTO : ScriptableObject
    {
        //Player Data
        public Vector3 Position { get; set; } = new Vector3(10, 2, 10);
        public float Speed { get; set; } = 5f;
        public float Stamina { get; set; } = 10f;
        public float Hp { get; set; } = 10f;
        public float AimSpeed { get; set; } = 2f;


        //World Data
        public Vector3 PlatformSize { get; set; } = new Vector3(40, 1, 20);


        //Enemy Data
    }
}
