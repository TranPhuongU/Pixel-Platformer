using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealBarPlayer2 : MonoBehaviour
{
    public Slider healthSlider;
    Dameable playerDameable;
    // Start is called before the first frame update
    void Start()
    {
        
        healthSlider.value = CalculateSliderPercentage(playerDameable.Health, playerDameable.MaxHealth);

    }
    private void Awake()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerDameable = player.GetComponent<Dameable>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private float CalculateSliderPercentage(int currentHealth, int maxHealth)
    {
        return currentHealth / maxHealth;
    }
}
