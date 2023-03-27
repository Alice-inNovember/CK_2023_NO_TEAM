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

    public void CardSpawn(int code)
    {
        GameObject newCard = Instantiate(CardPrefab);
        newCard.GetComponent<CardInit>().Init(_cardData.ChoiceDic[code * 2], _cardData.ChoiceDic[code * 2 + 1]);
    }
}
