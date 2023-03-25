using UnityEngine;

namespace _02_Scripts
{
    public class GameManager : MonoBehaviour
    {
	    private StatusManager _statusManager;
	    private CardChoiceInit _cardData;

	    private void Start()
        {
	        _statusManager = this.GetComponent<StatusManager>();
	        _cardData = new CardChoiceInit();
        }

	    public void RunChoice(int code)
	    {
		    if (!_cardData.ChoiceDic.ContainsKey(code)) return;
		    
		    var card = _cardData.ChoiceDic[code];
		    card.Show();
		    _statusManager.add_statusA(card.StatA);
		    _statusManager.add_statusB(card.StatB);
	    }
    }
}
