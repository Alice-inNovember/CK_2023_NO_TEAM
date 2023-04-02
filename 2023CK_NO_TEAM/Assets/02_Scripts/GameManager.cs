using UnityEngine;
using System.Linq;
using DG.Tweening;
using UnityEngine.SceneManagement;


using UnityEngine.UI;
using Image = UnityEngine.UIElements.Image;

namespace _02_Scripts
{
    public class GameManager : MonoBehaviour
    {
	    public Sprite[] TreeImg;// 턴수 췌크
	    
	    private StatusManager _statusManager;
	    private CardChoiceInit _cardData;
	    private GameObject _treeObj;
	    private GameObject _treeShade;
	    private GameObject _nextButton;
	    private int[] _cardQue; // 카드 효과 남은 턴
	    private int[] _cardUsed; // 카드 중복 생성을 막기 위한 변수
	    private int _turnCnt;

	    private void Start()
        {
	        _statusManager = this.GetComponent<StatusManager>();
	        _cardData = new CardChoiceInit();
	        _cardQue = Enumerable.Repeat<int>(0, _cardData.ChoiceDic.Count).ToArray<int>(); // 딕셔너리 크기많큼 할당
	        _cardUsed = Enumerable.Repeat<int>(0, _cardData.ChoiceDic.Count).ToArray<int>(); // 딕셔너리 크기많큼 할당
	        DontDestroyOnLoad(this.gameObject);
	        _turnCnt = 0; //턴수 초기화
        }

	    public void Init()
	    {
		    _treeObj = GameObject.Find("TreeOBJ");
		    _treeShade = GameObject.Find("TreeShade");
		    _nextButton = GameObject.Find("NextButton");
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
	    }
	    
	    public void NextCard()
	    {
		    int code = 0;

		    _nextButton.SetActive(false);
		    switch (_turnCnt)
		    {
			    case 7:
				    _turnCnt++;
				    _treeShade.GetComponent<SpriteRenderer>().DOFade(0, 0);
				    _treeShade.transform.DOMove(new Vector3(0, 0, 0), 0, false);
				    _treeShade.GetComponent<SpriteRenderer>().DOFade(1, 1.25f).OnComplete(() =>
				    {
					    _treeObj.GetComponent<SpriteRenderer>().sprite = TreeImg[_turnCnt];
					    _treeShade.GetComponent<SpriteRenderer>().DOFade(0, 2f).OnComplete(() =>
					    {
						    _treeShade.transform.DOMove(new Vector3(0, 0, 50), 0, false);
						    _nextButton.SetActive(true);
					    });
				    });
				    return;
			    case > 7:
				    SceneManager.LoadScene("MainMenu");
				    return;
		    }
		    code = Random.Range(0, 7);
		    while (_cardUsed[code] == 1)
		    {
			    code = Random.Range(0, 7);
		    }
		    _cardUsed[code] = 1;
		    
		    _treeShade.GetComponent<SpriteRenderer>().DOFade(0, 0);
		    _treeShade.transform.DOMove(new Vector3(0, 0, 0), 0, false);
		    _treeShade.GetComponent<SpriteRenderer>().DOFade(1, 1.25f).OnComplete(()=>
		    {
			    _treeObj.GetComponent<SpriteRenderer>().sprite = TreeImg[_turnCnt];
			    _treeShade.GetComponent<SpriteRenderer>().DOFade(0, 2f).OnComplete(() =>
			    {
				    _treeShade.transform.DOMove(new Vector3(0, 0, 50), 0, false);
			    });
			    this.GetComponent<CardSpawner>().CardSpawn(code);
		    });
		    _turnCnt++;
	    }

	    public void RunChoice(int code) // 카드 코드에 따라 스테이터스 적용
	    {
		    if (!_cardData.ChoiceDic.ContainsKey(code)) return;
		    
		    var card = _cardData.ChoiceDic[code];
		    Debug.Log("Run Card Code : " + code);
		    _statusManager.add_statusA(card.StatA);
		    _statusManager.add_statusB(card.StatB);
		    _nextButton.SetActive(true);
	    }
    }
}
