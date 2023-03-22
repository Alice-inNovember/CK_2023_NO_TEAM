using UnityEngine;
using UnityEngine.UI;

namespace _02_Scripts
{
    public class StatusData
    {
        private static StatusData _instance;
        private static int _statusA;
        private static int _statusB;
        
        public static StatusData Instance
        {
            get
            {
                if(null == _instance)
                {
                    //게임 인스턴스가 없다면 하나 생성해서 넣어준다.
                    _instance = new StatusData();
                }
                return _instance;
            }
        }

        public StatusData()
        {
            _statusA = 50;
            _statusB = 50;
        }

        public int StatusA
        {
            get => _statusA;
            set => _statusA = value;
        }
        
        public int StatusB
        {
            get => _statusB;
            set => _statusB = value;
        }
    }
}
