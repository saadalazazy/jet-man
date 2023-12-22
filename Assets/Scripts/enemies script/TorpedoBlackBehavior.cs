using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorpedoBlackBehavior : MonoBehaviour
{
    GameObject player;
    [SerializeField] float speed;
    Vector3 dir;
    float rot;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position , player.transform.position ,speed * Time.deltaTime) ;
        dir = transform.position - player.transform.position ;
        rot = Mathf.Atan2(dir.y , dir.x) * Mathf.Deg2Rad;
        transform.rotation = Quaternion.Euler(0, 0, rot * 3300);

    }
}
