using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Main
{
    public class FirstPhase : BasePhase, IPhase
    {
        public FirstPhase(Action<GamePhases> changeState) { }
        public PhaseStates Phase { get; set; }

        public GamePhases GamePhase => GamePhases.first;

        public GamePhases NextPhase => GamePhases.second;

        public void Enter()
        {
            GameController.Instance.ChangeCreationOnPhase(GamePhases.first);
        }

        public void Exit()
        {
            
        }

        public void Update(float deltaTime)
        {
            Debug.Log("First Phase");
        }
    }
}
