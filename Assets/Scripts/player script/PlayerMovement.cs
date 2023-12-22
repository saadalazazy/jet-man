using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    Vector2 playerDir;
    Vector3 playerPos;
    float speedVal;
    [SerializeField] float maxSpeed;
    [SerializeField] float acceleration;
    Vector2 minBound;
    Vector2 maxBound;
    Rigidbody2D rb;
    [SerializeField] Animator anim;
    float timerHasWepon = 0;
    ShootingSystem shooter;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        shooter = GetComponent<ShootingSystem>();
    }
    private void Start()
    {
        initBounds();
    }
    private void Update()
    {
        move();
        animationManger();
    }

    private void animationManger()
    {
        if (playerDir == Vector2.zero)
        {
            anim.SetBool("isMoving", false);
        }
        else
        {
            anim.SetBool("isMoving", true);
        }
        if (shooter.getPlayerShoot())
        {
            anim.SetBool("isShooting", true);
            anim.SetBool("hasWepon", true);
            timerHasWepon = 0;
        }
        else
        {
            anim.SetBool("isShooting", false);
        }
        if (anim.GetBool("hasWepon") == true && anim.GetBool("isShooting") == false)
        {
            timerHasWepon += Time.deltaTime;
        }

        if (timerHasWepon > 10)
        {
            timerHasWepon = 0;
            anim.SetBool("hasWepon", false);
        }
    }

    private void move()
    {
        playerPos = playerDir;
        if (playerDir != Vector2.zero)
        {
            if (speedVal < maxSpeed)
                speedVal += acceleration * Time.deltaTime;
            else
                speedVal = maxSpeed;
        }
        else
            speedVal = 0;
        checkBounds();
    }

    private void checkBounds()
    {
        if (transform.position.x - 0.3 < minBound.x)
        {
            if (playerPos.x < 0)
                playerPos.x = 0;

        }
        if (transform.position.x + 0.3 > maxBound.x)
        {
            if (playerPos.x > 0)
                playerPos.x = 0;
        }
        if (transform.position.y - 0.7 < minBound.y)
        {
            if (playerPos.y < 0)
                playerPos.y = 0;
        }
        if (transform.position.y + 0.3 > maxBound.y)
        {
            if (playerPos.y > 0)
                playerPos.y = 0;
        }
    }

    private void initBounds()
    {
        Camera cam = Camera.main;
        minBound = cam.ViewportToWorldPoint(new Vector2(0, 0));
        maxBound = cam.ViewportToWorldPoint(new Vector2(1, 1));
    }

    private void FixedUpdate()
    {
        rb.velocity = playerPos * speedVal;
    }
    void OnMove(InputValue value)
    {
        playerDir = value.Get<Vector2>();
    }
    
}
