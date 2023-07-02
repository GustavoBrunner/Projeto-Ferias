
using System;
namespace Main.AgentsController.Commands
{
    public class StopRunCommand : BaseCommand
    {
        private string _name;
        private Action _action;
        public StopRunCommand(string name, Action action)
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
