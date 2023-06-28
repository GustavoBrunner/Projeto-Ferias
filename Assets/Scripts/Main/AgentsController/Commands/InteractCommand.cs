using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Main.AgentsController.Commands
{
    public class InteractCommand : BaseCommand
    {
        private Action _action;
        private string _name;
        public InteractCommand(string name, Action action)
        {
            this._name = name;
            this._action = action;
        }

        public override void Execute()
        {
            _action.Invoke();
        }
    }
}
