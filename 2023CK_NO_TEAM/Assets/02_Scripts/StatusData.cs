using UnityEngine;
using UnityEngine.UI;

namespace _02_Scripts
{
	public class StatusData // <싱글톤> status A, B 관리
	{
		private static StatusData _instance;
		private static int _statusA;
		private static int _statusB;
		
		public static StatusData Instance// 싱글톤!
		{
			get
			{
				if(null == _instance)
				{
					_instance = new StatusData();
				}
				return _instance;
			}
		}

		public StatusData()// 초기화 50 퍼센트!
		{
			_statusA = 50;
			_statusB = 50;
		}

		public int StatusA //연산자 오버라이드
		{
			get => _statusA;
			set => _statusA = value;
		}
		
		public int StatusB //연산자 오버라이드
		{
			get => _statusB;
			set => _statusB = value;
		}
	}
}
