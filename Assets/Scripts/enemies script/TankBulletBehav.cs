using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TankBulletBehav : MonoBehaviour
{
    GameObject player;
    Rigidbody2D rb;
    [SerializeField] float speed;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        Vector3 dirction = player.transform.position - transform.position;
        rb.velocity = new Vector2 (dirction.x , dirction.y).normalized * speed;

        float rot = Mathf.Atan2(-dirction.y , - dirction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0,0,rot);
    }

}
