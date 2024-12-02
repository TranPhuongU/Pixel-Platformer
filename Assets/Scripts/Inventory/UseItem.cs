using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour
{
    
    Dameable dameable;
    //public GameObject effect;
    private Transform player;
    HP hp;
    HealthBar healthBar;
    Animator animator;
    private Animator playerAnimator;

    Henshin henshin;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerAnimator = player.GetComponent<Animator>(); // Lấy Animator từ Player
        healthBar = FindObjectOfType<HealthBar>();
        hp = FindObjectOfType<HP>();
        dameable = FindObjectOfType<Dameable>();

        henshin = FindObjectOfType<Henshin>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UseHP()
    {
        if (hp != null)
        {

            hp.currentHP += 20; // Cộng thêm máu

            healthBar.UpdateBar(dameable.Health, dameable.MaxHealth);
           
        }
        if (dameable != null)
        {
            dameable.Health += 20;
            healthBar.UpdateBar(dameable.Health, dameable.MaxHealth);
        }
        if (playerAnimator != null)
        {
            playerAnimator.SetBool("isDrinkHP", true); // Gọi trigger
        }
        //Instantiate(effect, player.position, Quaternion.identity);// gọi ra animation
        Destroy(gameObject);
    }
    public void UseHenshin()
    {
        // Gọi hàm chuyển đổi player khi sử dụng bình nước
        henshin.SwitchToPlayer2();

        // Có thể loại bỏ bình nước khỏi inventory sau khi sử dụng
        Destroy(gameObject);
    }
}
