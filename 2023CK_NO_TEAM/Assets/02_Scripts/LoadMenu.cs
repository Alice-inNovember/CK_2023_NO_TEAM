using UnityEngine;
using UnityEngine.SceneManagement;

namespace _02_Scripts
{
    public class LoadMenu : MonoBehaviour
    {
        // Start is called before the first frame update
        private void Start()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
