using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Scripting;
using UnityEngine.UIElements;

namespace _02_Scripts
{
    public class CardInit : MonoBehaviour
    {
        public GameObject text;
        private GameManager _gamemanager;
        private int _yesCardCode;
        private int _noCardCode;
        
        public void YesCardAction()
        {
            Debug.Log("YesCardAction : " + _yesCardCode);
            _gamemanager.AddCardQue(_yesCardCode);
            _gamemanager.RunCardQue();
            Destroy(gameObject);
        }
        public void NoCardAction()
        {
            Debug.Log("NoCardAction : " + _noCardCode);
            _gamemanager.AddCardQue(_noCardCode);
            _gamemanager.RunCardQue();
            Destroy(gameObject);
        }
        public void Init(CardChoice cardYes, CardChoice cardNo)
        {
            _gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
            text.GetComponent<TextMeshProUGUI>().text = cardYes.Question;
            _yesCardCode = cardYes.Code;
            _noCardCode = cardNo.Code;
        }
    }
}
