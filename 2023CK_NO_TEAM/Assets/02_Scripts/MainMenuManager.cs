using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    public GameObject Title;
    public GameObject StartPlant;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 temp = Title.transform.position;
        Title.transform.DOMove(new Vector3(temp.x, temp.y + 0.25f, temp.z), 1).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutBack);
    }
    public void StartButton()
    {
        SceneManager.LoadScene("GamePlay");
    }
    
    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    public void ExitGameButton()
    {
        Application.Quit();
    }
    
    public void GamePlayButton()
    {
        StartPlant.SetActive(false);
    }
}
