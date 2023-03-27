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
            Debug.Log("YesCardAction : " + YesCardCode);
            _gamemanager.AddCardQue(YesCardCode);
        }
        public void NoCardAction()
        {
            Debug.Log("NoCardAction : " + NoCardCode);
            _gamemanager.AddCardQue(NoCardCode);
        }
        public void Init()
        {
            _gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
        }
    }
}
