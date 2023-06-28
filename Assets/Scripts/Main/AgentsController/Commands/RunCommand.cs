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
        public RunCommand(string name, Action action)
        {
            this._name = name;
            this._action = action;
        }
        public override void Execute()
        {
            this._action.Invoke();
        }
    }
}
