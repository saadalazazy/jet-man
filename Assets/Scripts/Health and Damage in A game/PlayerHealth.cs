using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.LowLevel;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int heart = 4;
    [SerializeField] GameObject effectPrefab;
    [SerializeField] Animator cameraShake;
    bool coolDownActivate = false;
    [SerializeField] SpriteRenderer playerSprite;
    Coroutine playerEffectDamage;
    [SerializeField] Animator animatorPlayer;
    Rigidbody2D rd;
    [SerializeField] AudioPlayer ExplosionEffect;
    [SerializeField] UnityEngine.UI.Image[] hearts;
    ShootingSystem shootingSystemEnable;
    PlayerMovement plmov;
    buttonScripts transisions;
    private void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        shootingSystemEnable = GetComponent<ShootingSystem>();
        plmov = GetComponent<PlayerMovement>();
        transisions = FindObjectOfType<buttonScripts>();
    }
    private void Update()
    {
        if (coolDownActivate && playerEffectDamage == null)
        {
            playerEffectDamage = StartCoroutine(coolDownEffect());
        }
        else if(!coolDownActivate && playerEffectDamage !=  null)
        {
            StopCoroutine(playerEffectDamage);
            playerEffectDamage = null;
            playerSprite.color = new Color32(255, 255, 255, 255);
        }
        if (gameObject.transform.position.y <= -10)
        {
            rd.gravityScale = 0;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag != "Bullet" && !coolDownActivate)
        {
            if(collision.tag != "bosstag")
                Destroy(collision.gameObject);
            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, 1);
            StartCoroutine(CameraShakeStart());
            StartCoroutine(coolDownStart());
            ExplosionEffect.playExplosionSoundEffect();
            if(heart != 0)
            {
                hearts[heart - 1].enabled = false;
                heart--;
            }
           
            if (heart < 1)
            {
                transisions.loadGameOver();
                shootingSystemEnable.enabled = false;
                plmov.enabled = false;
                animatorPlayer.SetBool("isDie", true);
                rd.gravityScale = 1;
            }
        }

    }
    public int getHeart()
    {
        return heart;
    }
    IEnumerator CameraShakeStart()
    {
        cameraShake.SetBool("cameraShake", true);
        yield return new WaitForSeconds(0.5f);
        cameraShake.SetBool("cameraShake", false);
    }
    IEnumerator coolDownStart()
    {
        coolDownActivate= true;
        yield return new WaitForSeconds(1.5f);
        coolDownActivate= false;
    }
    IEnumerator coolDownEffect()
    {
        while(true)
        {
            playerSprite.color = new Color32(255, 255, 255, 150);
            yield return new WaitForSeconds(0.1f);
            playerSprite.color = new Color32(255, 255, 255, 255);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
