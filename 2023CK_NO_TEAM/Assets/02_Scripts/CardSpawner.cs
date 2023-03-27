using System;
using System.Collections;
using System.Collections.Generic;
using _02_Scripts;
using UnityEngine;

public class CardSpawner : MonoBehaviour
{
    public GameObject CardPrefab;
    private CardChoiceInit _cardData;

    private void Start()
    {
        _cardData = new CardChoiceInit();
    }

    public void CardSpawn(int code) //카드 생성 코드
    {
        GameObject newCard = Instantiate(CardPrefab);
        newCard.GetComponent<CardInit>().Init(_cardData.ChoiceDic[code * 2], _cardData.ChoiceDic[code * 2 + 1]);
        //카드 yes 값은 홀수 no값은 짝수 이다
        //2개가 합해서 1카드에 들어감
    }
}
