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
        
        public void YesCardAction()// yes 버튼을 눌렀을때, 실행되는 부분
        {
            Debug.Log("YesCardAction : " + _yesCardCode);
            _gamemanager.AddCardQue(_yesCardCode);
            _gamemanager.RunCardQue();
            Destroy(gameObject);
        }
        public void NoCardAction() // no 버튼을 눌렀을때, 실행되는 부분
        {
            Debug.Log("NoCardAction : " + _noCardCode);
            _gamemanager.AddCardQue(_noCardCode);
            _gamemanager.RunCardQue();
            Destroy(gameObject);
        }
        public void Init(CardChoice cardYes, CardChoice cardNo) // 카드를 생성 후 카드 번호에 해당하는 정보 입력
        {
            _gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
            text.GetComponent<TextMeshProUGUI>().text = cardYes.Question;
            _yesCardCode = cardYes.Code;
            _noCardCode = cardNo.Code;
        }
    }
}
