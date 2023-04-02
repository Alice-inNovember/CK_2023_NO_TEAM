using UnityEngine;

namespace _02_Scripts
{
    public class GMCaller : MonoBehaviour
    {
        
        private GameObject _gameManager;
        private GameManager _gm;
        private StatusManager _sm;
        // Start is called before the first frame update
        void Start()
        {
            _gameManager = GameObject.Find("GameManager");
            _gm = _gameManager.GetComponent<GameManager>();
            _sm = _gameManager.GetComponent<StatusManager>();
            _gm.Init();
            _sm.Init();
        }

        public void NextButton()
        {
            _gm.NextCard();
        }
    }
}
