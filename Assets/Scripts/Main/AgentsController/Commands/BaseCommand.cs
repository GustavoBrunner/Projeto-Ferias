using UnityEngine;
namespace Main.AgentsController.Commands
{
    /// <summary>
    /// Criamos uma classe base para os comandos, que ser� abstrata, para n�o ser usada como componente
    /// e ter� um m�todo abstrato tamb�m, para ser sobrescrito depois.
    /// </summary>
    public abstract class BaseCommand : MonoBehaviour
    {
        protected virtual string name { get; set; }
        protected BaseCommand() { }
        public abstract void Execute();
        
    }
}
