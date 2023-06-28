using System;
namespace Main.AgentsController.Commands
{
    /// <summary>
    /// Classe que executará o comando de pulo do player.
    /// </summary>
    public class JumpCommand : BaseCommand
    {
        private string _name;
        private Action _action;

        public JumpCommand(string name, Action action)
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
