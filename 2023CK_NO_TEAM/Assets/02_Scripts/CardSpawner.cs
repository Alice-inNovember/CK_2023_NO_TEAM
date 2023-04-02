using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

// DOTWEEN 이동함수

namespace _02_Scripts
{
    public class CardSpawner : MonoBehaviour
    {
        public GameObject cardPrefab;
        private CardChoiceInit _cardData;

        private void Start()
        {
            _cardData = new CardChoiceInit();
        }

        public void CardSpawn(int code) //카드 생성 코드
        {
            GameObject newCard = Instantiate(cardPrefab);
            newCard.GetComponent<CardAction>().Init(_cardData.ChoiceDic[code * 2], _cardData.ChoiceDic[code * 2 + 1]);
            //카드 yes 값은 홀수 no값은 짝수 이다
            //2개가 합해서 1카드에 들어감
        
            newCard.transform.DOMove(new Vector3(0, 10f, 0), 1.5f, false).OnComplete(()=>{
                newCard.transform.DORotate(new Vector3(0, 0, 0), 0.45f);
            });
            //카드 생성시 에니메이션
        }
    }
}
