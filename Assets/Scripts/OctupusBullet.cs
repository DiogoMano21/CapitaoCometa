using System.Collections;
using UnityEngine;

public class OctupusBullet: MonoBehaviour
{
    public float speed;
    public int damage;
    public GameObject impactEffect;
    public Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        StartCoroutine("bulletDestroy");
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerMovement player = hitInfo.GetComponent<PlayerMovement>();
        if (player != null)
        {
            player.TakeDamage(damage);
            player.animator.SetTrigger("gotHurt");
            player.StartCoroutine("Hurt");
            player.StartCoroutine("Invunerable");
        }
        GameObject effect = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(effect, 0.35f);
    }

    IEnumerator bulletDestroy()
    {
        yield return new WaitForSeconds(2.5f);
        Destroy(gameObject);
        GameObject effect = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effect, 0.35f);
    }

}
