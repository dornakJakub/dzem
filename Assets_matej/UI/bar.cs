using UnityEngine;
using UnityEngine.UI;

namespace ui
{
    public class ProgressBar : MonoBehaviour
    {
        public static ProgressBar Instance;
        public int maximum;
        public int current;

        public Image mask;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }

            current = 0;
        }

        void GetCurrentFill()
        {
            float fillAmount = current / (float)maximum;
            mask.fillAmount = fillAmount;

            if (current > maximum)
            {
                current = maximum;
            }
            else if (current <= 0)
            {
                current = 0;
            }
        }

        int GetCurrent()
        {
            return current;
        }

        void ResetCurrent()
        {
            current = 0;
        }

        public void SetCurrent(int points)
        {
            current = points;
            GetCurrentFill();
        }
    }
}