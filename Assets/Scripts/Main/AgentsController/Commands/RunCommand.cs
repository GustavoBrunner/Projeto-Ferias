using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Main.AgentsController.Commands {
    /// <summary>
    /// Classe que executará o comando de corrida do player.
    /// </summary>
    public class RunCommand : BaseCommand
    {
        private string _name;
        private Action _action;
        private Action _action1;
        public RunCommand(string name, Action action, Action action1)
        {
            this._name = name;
            this._action = action;
            this._action1 = action1;
        }
        public override void Execute()
        {
            this._action.Invoke();
        }
        public void StopExecute()
        {
            this._action1.Invoke();
        }
    }
}
