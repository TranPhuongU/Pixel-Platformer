using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPro : MonoBehaviour
{
    Henshin henshin;
    public int attackDamage = 10;
    // bị đánh sẽ lùi về sau 1 chút
    public Vector2 knockback = Vector2.zero;
    GameObject target;
    public float speed;
    Rigidbody2D bulletRB;
    Player player;
    public int minDame;
    public int maxDame;

    // Start is called before the first frame update
    void Start()
    {

        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
        bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);
        Destroy(this.gameObject, 2);
        henshin = FindObjectOfType<Henshin>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Dameable dameable = collision.GetComponent<Dameable>();
        if (dameable != null)
        {
            Vector2 deliveredKnockback = transform.localScale.x > 0 ? knockback : new Vector2(-knockback.x, knockback.y);

            bool gotHit = dameable.Hit(attackDamage, deliveredKnockback);
            if (gotHit)
            {
                Debug.Log("-10");
            }
        }
        if (collision.CompareTag("Player") && henshin.isHenshin==false)
        {
            // Lấy đối tượng Player
            Player player = collision.GetComponent<Player>();
            if (player != null && player.isDashing)
            {
                return; // Không làm gì nếu Player đang Dash
            }

            // Tính sát thương
            int dame = Random.Range(minDame, maxDame);
            player.TakeDamage(dame);
            Destroy(gameObject);
        }
    }
}
