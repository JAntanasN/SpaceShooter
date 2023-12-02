using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class SpaceShip : MonoBehaviour
{
    public float speed = 10;

    private bool isMoving = false;


    [Header("SpaceShipAudio")]
    public AudioSource audioSource;
    public AudioClip audioClip;

    [Header("Bullet")]
    public GameObject bulletPrefab;
    public float fireRate = 2;
    public Transform firePoint;

    [Header("BulletSound")]
    public AudioSource audiosource;
    public AudioClip audioclip;


    private void Start()
    {
        InvokeRepeating(nameof(Shoot), fireRate, fireRate);
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, transform.rotation);
        BulletSound();
    }

    void BulletSound()
    {
        audiosource.clip = audioclip;
        audiosource.Play();
    }



    void Update()
    {
        var direction = new Vector3();

        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");

        

        transform.position += direction * speed * Time.deltaTime; //timeDeltatime - time beetwen frame

        if (direction != Vector3.zero)
        {
            transform.forward = direction;
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }


        if (isMoving)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.clip = audioClip;
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }
    }
}
