using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public float smoothSpeed = 5f;
    private float targetHealth = 100f;
    

    void Update()
    {
        slider.value = Mathf.Lerp(slider.value, targetHealth, smoothSpeed * Time.deltaTime);
    }
    
    
    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    
    public void SetTargetHealth(float health)
    {
        targetHealth = health;
    }
    
}
