using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Main.FSM
{
    public class FSMPhases : MonoBehaviour
    {
        /// <summary>
        /// Armazenamos as fases que o jogo ter� dentro de um dicion�rio de fases, 
        /// onde passaremos de par�metros um gamephase e a fase em si, para ser acessado pela interface.
        /// </summary>
        public Dictionary<GamePhases, IPhase> phases = new Dictionary<GamePhases, IPhase>();
        /// <summary>
        /// refer�ncia da interface para que possamos acessar suas informa��es
        /// </summary>
        public IPhase CurrentPhase { get; protected set; }
        /// <summary>
        /// pr�ximo estado a ser chamado
        /// </summary>
        protected IPhase NextPhase;
        /// <summary>
        /// M�todo que escreve as fases no dicion�rio
        /// </summary>
        /// <param name="phase">Phase que ser� passada para ser adicionada</param>
        public void AddPhases(IPhase phase)
        {
            phases.Add(phase.GamePhase, phase);
        }
        /// <summary>
        /// M�todo para alterar a fase atual. Nossa FSM de fases s� ir� para frente, n�o voltar� estados
        /// </summary>
        /// <param name="gPhase">Nome da phase que ser� a pr�xima</param>
        public void ChangePhase(GamePhases gPhase)
        {
            var gphase = phases[gPhase];
            NextPhase = gphase;
        }
        /// <summary>
        /// A primeira inicializa��o da FSM
        /// </summary>
        /// <param name="gPhase">enum passado para que a phase seja achada dentro do dicion�rio</param>
        public void StartFSM(GamePhases gPhase)
        {
            var phase = phases[gPhase];
            StartFSM(phase);
        }
        /// <summary>
        /// sobrescri��o do m�todo anterior, agora recebendo uma interface
        /// </summary>
        /// <param name="phase">Interface encontrada no m�todo anterior</param>
        public void StartFSM(IPhase phase)
        {
            CurrentPhase = phase;
            CurrentPhase.Phase = PhaseStates.enter;
        }
        /// <summary>
        /// loop da FSM: a fun��o enter tocar� uma vez somente, trocando a fase para o update, que ficar� se repetindo
        /// at� que mudemos para outro estado. No caso de ser Exit, a fase atual ser� trocada pela pr�xima, e a fun��o enter dela
        /// ser� chamada
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
