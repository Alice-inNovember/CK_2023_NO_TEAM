using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace _02_Scripts
{
    public class StatusManager : MonoBehaviour
    {
        private StatusData _statusData;
        private Slider _sliderA;
        private Slider _sliderB;

        private void Start()
        {
            _statusData = new StatusData();
        }

        public void Init()
        {
            _sliderA = GameObject.Find("StatusA").GetComponent<Slider>();
            _sliderB = GameObject.Find("StatusB").GetComponent<Slider>();
            _statusData.StatusA = 50;
            _statusData.StatusB = 50;
            if (_sliderA != null)
                _sliderA.value = ((float)_statusData.StatusA / 100);
            if (_sliderB != null)
                _sliderB.value = ((float)_statusData.StatusB / 100);
        }
        public void add_statusA(int value) //스텟 증가 및 슬라이더 조정
        {
            int status;

            status = _statusData.StatusA;
            status += value;
            _statusData.StatusA = status;
            _sliderA.value = ((float)status / 100);
            switch (status) //해당하는 수치에 해당시 게임오버
            {
                case >= 100:
                    SceneManager.LoadScene("BadEnd");
                    break;
                case <= 0:
                    SceneManager.LoadScene("BadEnd");
                    break;
            }
        }
        
        public void add_statusB(int value) //스텟 증가 및 슬라이더 조정
        {
            int status;

            status = _statusData.StatusB;
            status += value;
            _statusData.StatusB = status;
            _sliderB.value = ((float)status / 100);
            switch (status) //해당하는 수치에 해당시 게임오버
            {
                case >= 100:
                    SceneManager.LoadScene("BadEnd");
                    break;
                case <= 0:
                    SceneManager.LoadScene("BadEnd");
                    break;
            }
        }
    }
}
