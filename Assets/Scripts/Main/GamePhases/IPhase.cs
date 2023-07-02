using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Main
{
    /// <summary>
    /// Interface que dar� acesso �s informa��es das phases
    /// </summary>
    public interface IPhase
    {
        PhaseStates Phase { get; set; }
        public GamePhases GamePhase { get; }
        public GamePhases NextPhase { get; }

        void Enter();
        void Exit();
        void Update(float deltaTime);


    }
}
