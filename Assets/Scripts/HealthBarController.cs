using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    private Image barImage;

    public const int HEALTH_MAX = 100;

    public float healthAmount;

    // Start is called before the first frame update
    void Awake()
    {
        barImage = transform.Find("Bar").GetComponent<Image>();

        healthAmount = 100;
    }

    // Update is called once per frame
    void Update()
    {
        barImage.fillAmount = healthAmount / HEALTH_MAX;

        if (healthAmount > HEALTH_MAX)
        {
            healthAmount = 100f;
        }
    }
}
