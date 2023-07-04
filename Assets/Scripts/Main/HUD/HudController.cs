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
        private static HudController _instance;
        public static HudController Instance { get { return _instance; } }
        private TMP_Text staminaText;
        private void Awake()
        {
            CreateSingleton();
            staminaText = GameObject.Find("HUD").GetComponentInChildren<TMP_Text>();
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
                staminaText.text = value.ToString();
            }
        }
        public void GetData()
        {
            staminaText.text = PlayerController.Instance.Stamina.ToString();
        }
        private void CreateSingleton()
        {
            if (_instance == null)
            {
                _instance = this;
            }
            else
            {
                DestroyImmediate(Instance);
                _instance = this;
            }
        }
    }
}
