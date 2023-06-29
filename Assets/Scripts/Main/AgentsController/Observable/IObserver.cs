using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Main.AgentsController.Observable
{
    public interface IObserver 
    {
        void OnNotify<T>(NotificationType type, T value);
        //ESSA � A MALDITA ESTRUTURA DE UMA INTERFACE GEN�RICA, PORRA DO CARALHOOOOOOOOOOOOOOO
        /*
         * Generics s�o usados depois do nome de um m�todo, e se ele � colocado l�, deve ser tomado como par�metro tamb�m
         * ao fazer uma classe gen�rica podemos tomar o tipo gen�rico como tipo de vari�veis. S� assim � poss�vel fazer um tipo gen�rico
         
         */
    }
}
