using System.Collections.Generic;
using UnityEngine;


namespace _02_Scripts
{
    public class CardChoice
    {
        public int Code;
        public string Question;
        public int StatA;
        public int StatB;
        public int Turn;

        public void Show()
        {
            Debug.Log("Card Code : " + this.Code);
            Debug.Log("Question  : " + this.Question);
            Debug.Log("StatA     : " + this.StatA);
            Debug.Log("StatB     : " + this.StatB);
            Debug.Log("Turn      : " + this.Turn);
        }
    }
    
    public class CardChoiceInit
    {
        public Dictionary<int, CardChoice> ChoiceDic;
        private static CardChoiceInit _instance;
        private static int _statusA;
        private static int _statusB;
		
        public static CardChoiceInit Instance
        {
            get
            {
                if(null == _instance)
                {
                    _instance = new CardChoiceInit();
                }
                return _instance;
            }
        }
        public CardChoiceInit()
        {
            ChoiceDic = new Dictionary<int, CardChoice>();
            this.Init();
        }

        private void Init()
        {
            var cardDictionary = CsvReader.Read("Card_Choice");
            for (var i = 0; i < cardDictionary.Count; i++)
            {
                var newCard = new CardChoice
                {
                    Code = int.Parse(cardDictionary[i]["CODE"].ToString()),
                    Question = cardDictionary[i]["QUESTION"].ToString(),
                    StatA = int.Parse(cardDictionary[i]["STAT_A"].ToString()),
                    StatB = int.Parse(cardDictionary[i]["STAT_B"].ToString()),
                    Turn = int.Parse(cardDictionary[i]["TURN"].ToString())
                };
                ChoiceDic.Add(i, newCard);
            }
        }
    } 
}
