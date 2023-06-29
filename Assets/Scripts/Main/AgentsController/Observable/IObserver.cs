using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Main.AgentsController.Observable
{
    public interface IObserver 
    {
        void OnNotify<T>(NotificationType type, T value);
        //ESSA É A MALDITA ESTRUTURA DE UMA INTERFACE GENÉRICA, PORRA DO CARALHOOOOOOOOOOOOOOO
        /*
         * Generics são usados depois do nome de um método, e se ele é colocado lá, deve ser tomado como parâmetro também
         * ao fazer uma classe genérica podemos tomar o tipo genérico como tipo de variáveis. Só assim é possível fazer um tipo genérico
         
         */
    }
}
