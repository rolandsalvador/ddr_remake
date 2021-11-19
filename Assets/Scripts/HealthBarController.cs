using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    private Image barImage;

    public const int HEALTH_MAX = 100;

    public float healthAmount;
    //public float healthAmount = Mathf.Clamp(100f, 0f, 100f);
    public float healthRegenAmount;

    // Start is called before the first frame update
    void Awake()
    {
        barImage = transform.Find("Bar").GetComponent<Image>();

        //healthAmount = 100;
        healthAmount = Mathf.Clamp(healthAmount, 0f, 100f);
        healthRegenAmount = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        healthAmount += healthRegenAmount * Time.deltaTime;

        barImage.fillAmount = healthAmount / HEALTH_MAX;
    }
}
