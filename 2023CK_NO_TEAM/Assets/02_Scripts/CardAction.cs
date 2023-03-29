using TMPro;
using UnityEngine;
using DG.Tweening;


namespace _02_Scripts
{
    public class CardAction : MonoBehaviour
    {
        public GameObject text;
        private GameManager _gm;
        private int _yesCardCode;
        private int _noCardCode;
        
        public void YesCardAction()// yes 버튼을 눌렀을때, 실행되는 부분
        {
            Debug.Log("YesCardAction : " + _yesCardCode);
            _gm.AddCardQue(_yesCardCode);
            _gm.RunCardQue();
            this.transform.DORotate(new Vector3(0, 0, 180), 0.45f).OnComplete(()=>
            {
                this.transform.transform.DOMove(new Vector3(0, 10, -50), 2, false).OnComplete(() =>
                {
                    Destroy(gameObject);
                });
            });
        }
        public void NoCardAction() // no 버튼을 눌렀을때, 실행되는 부분
        {
            Debug.Log("NoCardAction : " + _noCardCode);
            _gm.AddCardQue(_noCardCode);
            _gm.RunCardQue();
            this.transform.DORotate(new Vector3(0, 0, 180), 0.45f).OnComplete(()=>
            {
                this.transform.transform.DOMove(new Vector3(0, 10, -50), 2, false).OnComplete(() =>
                {
                    Destroy(gameObject);
                });
            });
        }
        public void Init(CardChoice cardYes, CardChoice cardNo) // 카드를 생성 후 카드 번호에 해당하는 정보 입력
        {
            _gm = GameObject.Find("GameManager").GetComponent<GameManager>();
            text.GetComponent<TextMeshProUGUI>().text = cardYes.Question;
            _yesCardCode = cardYes.Code;
            _noCardCode = cardNo.Code;
        }
    }
}