using UnityEngine;
using System.Linq;

namespace _02_Scripts
{
    public class GameManager : MonoBehaviour
    {
	    private StatusManager _statusManager;
	    private CardChoiceInit _cardData;
	    private int[] _cardQue; // 카드 효과 남은 턴
	    private int[] _cardUsed; // 카드 중복 생성을 막기 위한 변수

	    private void Start()
        {
	        _statusManager = this.GetComponent<StatusManager>();
	        _cardData = new CardChoiceInit();
	        _cardQue = Enumerable.Repeat<int>(0, _cardData.ChoiceDic.Count).ToArray<int>(); // 딕셔너리 크기많큼 할당
	        _cardUsed = Enumerable.Repeat<int>(0, _cardData.ChoiceDic.Count).ToArray<int>(); // 딕셔너리 크기많큼 할당
        }

	    public void RunCardQue() // 카드중 여러 턴 동안 작동하는 값이 있어 _cardQue에 남은 수 많큼 적용할 수 있도록 함
	    {
		    for (int i = 0; i < _cardData.ChoiceDic.Count; i++)
		    {
			    switch (_cardQue[i])
			    {
				    case > 0:
					    RunChoice(i);
					    _cardQue[i]--;
					    break;
				    case -1: // -1 은 게임 끝나기까지 매턴 적용
					    RunChoice(i);
					    break;
			    }
		    }
	    }

	    public void AddCardQue(int code) // 선택지 설정 후 효과(스테이터스) 적용을 위한 큐 증가
	    {
		    _cardQue[code] = _cardData.ChoiceDic[code].Turn;
		    _cardUsed[code] = 1;
	    }

	    public void RunChoice(int code) // 카드 코드에 따라 스테이터스 적용
	    {
		    if (!_cardData.ChoiceDic.ContainsKey(code)) return;
		    
		    var card = _cardData.ChoiceDic[code];
		    Debug.Log("Run Card Code : " + code);
		    _statusManager.add_statusA(card.StatA);
		    _statusManager.add_statusB(card.StatB);
	    }
    }
}
