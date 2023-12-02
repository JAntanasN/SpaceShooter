using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsMoving : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float changeInterval = 3f;

    public GameObject explosionVfx;

    private Rigidbody rb;
    private Vector3 randomDirection;

    [Header("ExplosionSound")]
    public AudioSource audiosource;
    public AudioClip audioclip;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        InvokeRepeating("ChangeDirection", 0f, changeInterval);
    }

   
    void Update()
    {
       
        Vector3 newPosition = transform.position + new Vector3(randomDirection.x, 0f, randomDirection.z) * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(newPosition);
    }

    void ChangeDirection()
    {
        randomDirection = Random.insideUnitSphere; 
        randomDirection.y = 2f;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            ExplosionSound();
            Explode();
        }
    }

    void ExplosionSound()
    {
        audiosource.clip = audioclip;
        audiosource.Play();
    }

    void Explode()
    {
        Instantiate(explosionVfx, transform.position, Quaternion.identity);
        
    }
}
