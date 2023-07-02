using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Main.FSM
{
    public class FSMPhases : MonoBehaviour
    {
        /// <summary>
        /// Armazenamos as fases que o jogo terá dentro de um dicionário de fases, 
        /// onde passaremos de parâmetros um gamephase e a fase em si, para ser acessado pela interface.
        /// </summary>
        public Dictionary<GamePhases, IPhase> phases = new Dictionary<GamePhases, IPhase>();
        /// <summary>
        /// referência da interface para que possamos acessar suas informações
        /// </summary>
        public IPhase CurrentPhase { get; protected set; }
        /// <summary>
        /// próximo estado a ser chamado
        /// </summary>
        protected IPhase NextPhase;
        /// <summary>
        /// Método que escreve as fases no dicionário
        /// </summary>
        /// <param name="phase">Phase que será passada para ser adicionada</param>
        public void AddPhases(IPhase phase)
        {
            phases.Add(phase.GamePhase, phase);
        }
        /// <summary>
        /// Método para alterar a fase atual. Nossa FSM de fases só irá para frente, não voltará estados
        /// </summary>
        /// <param name="gPhase">Nome da phase que será a próxima</param>
        public void ChangePhase(GamePhases gPhase)
        {
            var gphase = phases[gPhase];
            NextPhase = gphase;
        }
        /// <summary>
        /// A primeira inicialização da FSM
        /// </summary>
        /// <param name="gPhase">enum passado para que a phase seja achada dentro do dicionário</param>
        public void StartFSM(GamePhases gPhase)
        {
            var phase = phases[gPhase];
            StartFSM(phase);
        }
        /// <summary>
        /// sobrescrição do método anterior, agora recebendo uma interface
        /// </summary>
        /// <param name="phase">Interface encontrada no método anterior</param>
        public void StartFSM(IPhase phase)
        {
            CurrentPhase = phase;
            CurrentPhase.Phase = PhaseStates.enter;
        }
        /// <summary>
        /// loop da FSM: a função enter tocará uma vez somente, trocando a fase para o update, que ficará se repetindo
        /// até que mudemos para outro estado. No caso de ser Exit, a fase atual será trocada pela próxima, e a função enter dela
        /// será chamada
        /// </summary>
        private void Update()
        {
            if( CurrentPhase != null)
            {
                switch(CurrentPhase.Phase)
                {
                    case PhaseStates.none: 
                        break;
                    case PhaseStates.enter:
                        CurrentPhase.Enter();
                        CurrentPhase.Phase = PhaseStates.update;
                        break;
                    case PhaseStates.update:
                        float deltaTime = Time.deltaTime;
                        CurrentPhase.Update(deltaTime);
                        break;
                    case PhaseStates.exit:
                        CurrentPhase.Exit();
                        if(NextPhase != null)
                        {
                            CurrentPhase = NextPhase;
                            NextPhase = null;
                            CurrentPhase.Phase = PhaseStates.enter;
                        }
                        break;
                    default:
                        Debug.Log("Unknown phase");
                        Debug.Break();
                        break;
                }
            }
            if(NextPhase != null)
            {
                CurrentPhase.Phase = PhaseStates.exit;
            }
        }
    }
}
