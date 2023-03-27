using System.Collections.Generic;
using UnityEngine;


namespace _02_Scripts
{
    public class CardChoice // 카드 하나에 대한 정보
    {
        public int Code;
        public string Question;
        public int StatA;
        public int StatB;
        public int Turn;

        public void Show() // 디버그용 코드
        {
            Debug.Log("Card Code : " + this.Code);
            Debug.Log("Question  : " + this.Question);
            Debug.Log("StatA     : " + this.StatA);
            Debug.Log("StatB     : " + this.StatB);
            Debug.Log("Turn      : " + this.Turn);
        }
    }
    
    public class CardChoiceInit // csv파일에서 정보를 읽어서 딕셔너리화 시키는 함수, <싱글톤> 정보가 필요할시 할당받아 사용
    {
        public Dictionary<int, CardChoice> ChoiceDic; // 카드 정보가 담겨있는 딕셔너리
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
            //csv파일 파서
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
