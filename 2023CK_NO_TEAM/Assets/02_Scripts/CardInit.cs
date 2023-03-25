using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Scripting;
using UnityEngine.UIElements;

namespace _02_Scripts
{
    public class CardInit : MonoBehaviour
    {
        private GameManager _gamemanager;
        public int YesCardCode;
        public int NoCardCode;

        private void Start()
        {
            YesCardCode = 0;
            NoCardCode = 1;
            Init();
        }

        public void YesCardAction()
        {
            Debug.Log("OK Yes!");
            _gamemanager.RunChoice(YesCardCode);
        }
        public void NoCardAction()
        {
            Debug.Log("OK No!");
            _gamemanager.RunChoice(NoCardCode);
        }
        public void Init()
        {
            _gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
        }
    }
}
