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
        protected override string name { get; set; }
        private Action player;
        public ShootCommand(string name, Action action)
        {
            this.name = name;
            this.player = action;
        }
        public override void Execute()
        {
            Debug.Log($"Using {this.name} command");
            player.Invoke();
        }
    }
}
