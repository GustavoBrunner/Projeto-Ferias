using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Main.AgentsController.Observable;
using Main.AgentsController;
using TMPro;
namespace Main
{
    public class HudController : MonoBehaviour, IObserver
    {
        private static HudController instance;
        public static HudController Instance { get { return instance; } }
        private TMP_Text _staminaText;
        private void Awake()
        {
            CreateSingleton();
            _staminaText = GameObject.Find("HUD").GetComponentInChildren<TMP_Text>();
        }
        private void Start()
        {
            
        }
        public void OnNotify<T>(NotificationType type, T value)
        {
            var observation = value;
            if (type == NotificationType.damage)
            {
                var damage = float.Parse(value.ToString());
                
                Debug.Log(damage);
            }
            if(type == NotificationType.none)
            {
                Debug.Log(observation);
            }
            if(type == NotificationType.stamina)
            {
                _staminaText.text = value.ToString();
            }
        }
        public void GetData()
        {
            _staminaText.text = PlayerController.Instance.Stamina.ToString();
        }
        private void CreateSingleton()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                DestroyImmediate(Instance);
                instance = this;
            }
        }
    }
}
