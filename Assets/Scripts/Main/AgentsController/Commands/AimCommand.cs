using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Main.AgentsController.Commands
{
    public class AimCommand : BaseCommand
    {
        private string name;
        private Action action;
        public AimCommand(string name, Action action)
        {
            this.name = name;
            this.action = action;
        }

        public override void Execute()
        {
            this.action.Invoke();
        }
    }
}
