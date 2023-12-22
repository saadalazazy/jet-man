using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMovment : MonoBehaviour
{
    Vector3 bulletSpeed;
    [SerializeField] float bulletSpeedX = 10f;
    private void Start()
    {
        bulletSpeed = new Vector3(bulletSpeedX , 0 , 0);
    }
    void Update()
    {
        transform.position += bulletSpeed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "wall")
        {
            Destroy(gameObject);
        }
    }
}
