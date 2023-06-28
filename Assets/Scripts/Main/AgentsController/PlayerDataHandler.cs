using System;
using UnityEngine;

namespace Main.AgentsController
{
    public class DataHandlerDelegates
    {
        public Func<Vector3> Position;
        public Func<Quaternion> Rotation;

    }
    public class PlayerDataHandler : IPlayerData
    {

        public DataHandlerDelegates delegates;
        public PlayerDataHandler(DataHandlerDelegates delegates)
        {
            this.delegates = delegates;
        }
        Vector3 IPlayerData.Position { get => delegates.Position(); }
        Quaternion IPlayerData.Rotation { get => delegates.Rotation();}

    }
    
}
