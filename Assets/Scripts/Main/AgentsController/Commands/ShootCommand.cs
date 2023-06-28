using UnityEngine;
using System;
namespace Main.AgentsController.Commands
{
    /// <summary>
    /// Comando que sobrescreveu o base. Aqui é onde passaremo uma Action, sem retorno, e executaremos dela dentro do
    /// método Execute. Devemos fazer um construtor da classe, e instanciaremos ele seja num input controller, ou na classe do player
    /// </summary>
    public class ShootCommand : BaseCommand
    {
        private string _name { get; set; }
        private Action _player;
        public ShootCommand(string name, Action action)
        {
            this._name = name;
            this._player = action;
        }
        public override void Execute()
        {
            Debug.Log($"Using {this._name} command");
            _player.Invoke();
        }
    }
}
