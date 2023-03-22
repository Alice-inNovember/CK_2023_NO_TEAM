using UnityEngine;
using UnityEngine.UI;

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
            _sliderA = GameObject.Find("StatusA").GetComponent<Slider>();
            _sliderB = GameObject.Find("StatusB").GetComponent<Slider>();
            if (_sliderA != null)
                _sliderA.value = ((float)_statusData.StatusA / 100);
            if (_sliderB != null)
                _sliderB.value = ((float)_statusData.StatusB / 100);
        }

        public void add_statusA(int value)
        {
            int status;

            status = _statusData.StatusA;
            status += value;
            _statusData.StatusA = status;
            _sliderA.value = ((float)status / 100);
            switch (status)
            {
                case >= 100:
                    break;
                case <= 0:
                    break;
            }
        }
        
        public void add_statusB(int value)
        {
            int status;

            status = _statusData.StatusB;
            status += value;
            _statusData.StatusB = status;
            _sliderB.value = ((float)status / 100);
            switch (status)
            {
                case >= 100:
                    break;
                case <= 0:
                    break;
            }
        }
    }
}
