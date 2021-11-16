using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    private Health health;
    private Image barImage;

    // Start is called before the first frame update
    private void Awake()
    {
        barImage = transform.Find("Bar").GetComponent<Image>();

        health = new Health();
    }

    private void Update()
    {
        health.Update();

        barImage.fillAmount = health.GetHealthNormalized();
    }

    public class Health
    {
        public const int HEALTH_MAX = 100;

        private float healthAmount;
        private float healthRegenAmount;

        public Health()
        {
            healthAmount = 100;
            healthRegenAmount = 30f;
        }

        // Update is called once per frame
        public void Update()
        {
            healthAmount += healthRegenAmount * Time.deltaTime;

            if (healthAmount == 0)
            {
                
            }
        }

        public float GetHealthNormalized()
        {
            return healthAmount / HEALTH_MAX;
        }
    }
}
