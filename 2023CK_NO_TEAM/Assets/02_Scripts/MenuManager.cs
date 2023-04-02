using DG.Tweening;
using UnityEngine;
using UnityEngine.UIElements;

namespace _02_Scripts
{
    public class MenuManager : MonoBehaviour
    {
        public GameObject MenuCard;
        public GameObject MenuButton;
        public GameObject MenuShade;

        private FadeControl fdControl;

        // Start is called before the first frame update
        private void Start()
        {
            fdControl = MenuShade.GetComponent<FadeControl>();
            MenuButton.SetActive(true);
            MenuCard.transform.DOMove(new Vector3(0, 0, 50), 0, false);
            fdControl.image.DOFade(0, 0);
            MenuShade.SetActive(false);
        }

        public void MenuOpen()
        {
            MenuShade.SetActive(true);
            fdControl.image.DOFade(0.6f, 1);
            MenuCard.transform.DOMove(new Vector3(0, 50, 0), 1, false);
        }

        public void MenuClose()
        {
            MenuCard.transform.DOMove(new Vector3(0, 0, 50), 1, false);
            fdControl.image.DOFade(0f, 1).OnComplete(() =>
            {
                MenuShade.SetActive(false);
            });
        }
        
        public void ExitGame()
        {
            Application.Quit();
        }
    }
}
