using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Health : MonoBehaviour
{
    [SerializeField] float health;
    SpriteRenderer sp;
    [SerializeField] bool workEffect;
    [SerializeField] GameObject effectPrefab;
    AudioPlayer ExplosionEffect;
    buttonScripts transisions;

    private void Awake()
    {
        ExplosionEffect = FindObjectOfType<AudioPlayer>();
        transisions = FindObjectOfType<buttonScripts>();

    }
    private void Start()
    {
        if (workEffect)
            sp = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damage damage = collision.GetComponent<Damage>();

        if(damage != null && collision.tag == "Bullet")
        {
            health -= damage.GetDamage();
            damage.Dead();
            if (workEffect)
                StartCoroutine(DamgeEffect());
            if (health <= 0)
            {
                if(gameObject.tag == "bosstag")
                    transisions.loadwin();
                Destroy(gameObject);
                GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
                ExplosionEffect.playExplosionSoundEffect();
                Destroy(effect, 1);
            }
        }
    }

    IEnumerator DamgeEffect()
    {
        sp.color = new Color32(219, 219, 219, 255);
        yield return new WaitForSeconds(0.15f);
        sp.color = new Color32(255, 255, 255, 255);
    }
}
