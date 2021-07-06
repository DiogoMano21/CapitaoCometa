using UnityEngine;
using Random = System.Random;
using System.Collections;

public class EnemyWeapon : MonoBehaviour
{
    Random r = new Random();
    public Transform enemyFirePoint;
    public GameObject bulletPrefab;
    public float fireRate;
    float timeToShoot = 0f;
    public float timeBS;

    void Update()
    {
        if (Time.time > (timeToShoot + 1 / fireRate))
        {
            timeToShoot = Time.time;
            StartCoroutine("Shoot");
        }
    }

    private IEnumerator Shoot()
    {
        int n = getNB();
        for (int i = 0; i < n; i++)
        {
            Instantiate(bulletPrefab, enemyFirePoint.position, enemyFirePoint.rotation * Quaternion.Euler(0, 180, 0));
            yield return new WaitForSeconds(timeBS);
        }
    }

    private int getNB()
    {
        double d = r.NextDouble();
        if (d < 0.5) return 1;
        else if (d < 0.85) return 2;
        else return 3;
    }
}
