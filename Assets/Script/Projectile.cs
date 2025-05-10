using UnityEngine;


public class Projectile : MonoBehaviour
{

    public float speed = 10f;
    public float lifetime = 5f;
    public Transform target;
    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, lifetime);
        rb = GetComponent<Rigidbody>();

        Shoot();
    }

    void Shoot()
    {
        rb.angularVelocity = transform.forward * speed;
    }
    // Update is called once per frame
   
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(20);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
