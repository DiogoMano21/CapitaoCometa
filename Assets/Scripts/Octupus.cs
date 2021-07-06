using Random = System.Random;
using UnityEngine;

public class Octupus : MonoBehaviour
{
    public int health;
    public GameObject deathEffect;
    private int damage;
    private bool facingLeft = true;
    public PlayerMovement target;
    private Random r = new Random();

    private void Start()
    {
        OctupusBullet oB = new OctupusBullet();
        damage = oB.damage;
        Destroy(oB);
        health += getExtraHealth();
    }
    private void FixedUpdate()
    {
        Flip();
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Flip()
    {
        if (target != null)
        {
            target = FindObjectOfType<PlayerMovement>();
            if (target.transform.position.x > transform.position.x && facingLeft)
            {
                transform.Rotate(0f, 180f, 0f);
                facingLeft = false;
            }

            if (target.transform.position.x < transform.position.x && !facingLeft)
            {
                transform.Rotate(0f, 180f, 0f);
                facingLeft = true;
            }

        }
    }

    void Die()
    {
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(effect, 0.45f);
    }

    private int getExtraHealth()
    {
        double v = r.NextDouble();
        if (v < 0.3) return 0;
        else if (v < 0.6) return 20;
        else if (v < 0.8) return 40;
        else if (v < 0.95) return 60;
        else return 90;
    }
}
