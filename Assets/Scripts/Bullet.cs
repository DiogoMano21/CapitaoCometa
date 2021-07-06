using UnityEngine;
using System;
using Random = System.Random;

public class Bullet : MonoBehaviour
{
    public float Speed = 20f;
    public int damage = 40;
    public float range;
    public GameObject impactEffect;
    public Rigidbody2D rb;
    private Random r = new Random();

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * Speed;
        damage = getDamage();
       
        Destroy(gameObject, range);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Octupus octupus = hitInfo.GetComponent<Octupus>();
        Crab crab = hitInfo.GetComponent<Crab>();
        if(crab != null)
        {
            crab.TakeDamage(damage + critical());
        }
        if(octupus != null)
        {
            octupus.TakeDamage(damage + critical());
        }
        GameObject effect = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(effect, 0.35f);
    }
    int critical()
    {
        double a = 0.5 * 0.75;
        double b = 0.75 / Math.PI;
        return Convert.ToInt32(Math.Round((damage * (a + b * Math.Asin((new Random().NextDouble() * 2 - 1))))));
    }

    private int getDamage()
    {
        double v = r.NextDouble();
        if (v < 0.25) return 10;
        else if (v < 0.65) return 20;
        else if (v < 0.85) return 30;
        else if (v < 0.95) return 40;
        else return 50;
    }
}
