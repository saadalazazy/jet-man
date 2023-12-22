using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torpedoBehav : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Animator anim;
    [SerializeField] GameObject tornedoPrefab;
    Rigidbody2D rb;
    GameObject player;
    bool arriveTarget = false;
    bool isChooseRange = false;
    int targetPoint;
    bool isShoot = false;
    float deleyTime = 0;
    Vector3 dirction;
    Vector2 TowPoints1;
    Vector2 TowPoints2;
    Vector3 targetPoints;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        TowPoints1 = new Vector2 (-3.75f , 3.55f);
        TowPoints2 = new Vector2(-3.75f, -3.55f);
    }
    void Update()
    {
        torpedoMove();
    }

    private void torpedoMove()
    {
        if (!isChooseRange)
        {
            targetPoint = Random.Range(0, 2);
            if (targetPoint < 1)
                targetPoints = TowPoints1;
            else
                targetPoints = TowPoints2;
            dirction = targetPoints - transform.position;
            float rot = Mathf.Atan2(-dirction.y, -dirction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rot);
            isChooseRange = true;
        }
        if (!arriveTarget)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPoints, speed * Time.deltaTime);
        }
        if (transform.position == targetPoints)
        {
            arriveTarget = true;
            anim.SetBool("isRotating", true);
            deleyTime += Time.deltaTime;
        }
        if (deleyTime > 2 && !isShoot)
        {
            GameObject bullet = Instantiate(tornedoPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(bullet , 2);
            
        }
    }
}