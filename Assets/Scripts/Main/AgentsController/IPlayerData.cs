using UnityEngine;
namespace Main.AgentsController
{
    public interface IPlayerData
    {
        Vector3 Position { get; }
        Quaternion Rotation { get; }
    }    
}
