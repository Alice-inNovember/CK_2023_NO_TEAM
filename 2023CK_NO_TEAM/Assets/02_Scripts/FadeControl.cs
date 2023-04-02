using UnityEngine;
using UnityEngine.UI;

namespace _02_Scripts
{
    public class FadeControl : MonoBehaviour
    {
        public Image image;
        void Start ()
        {
            image = GetComponent<Image>();
        }
    }
}
