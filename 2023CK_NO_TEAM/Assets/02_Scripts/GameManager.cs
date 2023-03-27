using UnityEngine;
using System.Linq;

namespace _02_Scripts
{
    public class GameManager : MonoBehaviour
    {
	    private StatusManager _statusManager;
	    private CardChoiceInit _cardData;
	    private int[] _cardQue;
	    private int[] _cardUsed;

	    private void Start()
        {
	        _statusManager = this.GetComponent<StatusManager>();
	        _cardData = new CardChoiceInit();
	        _cardQue = Enumerable.Repeat<int>(0, _cardData.ChoiceDic.Count).ToArray<int>();
	        _cardUsed = Enumerable.Repeat<int>(0, _cardData.ChoiceDic.Count).ToArray<int>();
        }

	    public void RunCardQue()
	    {
		    for (int i = 0; i < _cardData.ChoiceDic.Count; i++)
		    {
			    switch (_cardQue[i])
			    {
				    case > 0:
					    RunChoice(i);
					    _cardQue[i]--;
					    break;
				    case -1:
					    RunChoice(i);
					    break;
			    }
		    }
	    }

	    public void AddCardQue(int code)
	    {
		    _cardQue[code] = _cardData.ChoiceDic[code].Turn;
		    _cardUsed[code] = 1;
	    }

	    public void RunChoice(int code)
	    {
		    if (!_cardData.ChoiceDic.ContainsKey(code)) return;
		    
		    var card = _cardData.ChoiceDic[code];
		    Debug.Log("Run Card Code : " + code);
		    _statusManager.add_statusA(card.StatA);
		    _statusManager.add_statusB(card.StatB);
	    }
    }
}
