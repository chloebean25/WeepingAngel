using UnityEngine;

public class Launcher : MonoBehaviour
{
   public GameObject ProjectilePrefab;
    public Transform launchPoint;
    public float fireRate = 2f;
    public float launchForce = 10f;

    private float nextFire;

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextFire)
        {
            FireProjectile();
            nextFire = Time.time + fireRate;
        }
    }
    void FireProjectile()
    {
        GameObject projectile = Instantiate(ProjectilePrefab, launchPoint.position, launchPoint.rotation);
        Projectile projectileScript = projectile.GetComponent<Projectile>();
        if (projectileScript != null )
        {
            projectileScript.target = GameObject.FindGameObjectWithTag("Player").transform;
        }

        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if(rb != null )
        {
            rb.AddForce(launchPoint.forward * launchForce, ForceMode.Impulse);
        }
    }

}
