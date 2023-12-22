using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootingSystem : MonoBehaviour
{
    bool playerShoot;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float delayTime;
    [SerializeField] Transform pointShoot;
    Coroutine fireCoroutin;
    [SerializeField] AudioPlayer shootingSound;
    void Update()
    {
        if (playerShoot && fireCoroutin == null)
        {
            fireCoroutin = StartCoroutine(shooting());
        }
        else if (!playerShoot && fireCoroutin != null)
        {
            StopCoroutine(fireCoroutin);
            fireCoroutin = null;
        }
    }
    IEnumerator shooting()
    {
        while (true)
        {
            GameObject bullet = Instantiate(bulletPrefab, pointShoot.position, Quaternion.identity);
            shootingSound.playShootingSoundEffect();
            yield return new WaitForSeconds(delayTime);
        }
       

    }
    void OnFire(InputValue input)
    {
        playerShoot = input.isPressed;
    }
    public bool getPlayerShoot() {
        return playerShoot;
    } 
}
