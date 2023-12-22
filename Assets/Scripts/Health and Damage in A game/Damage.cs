using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] float damage = 0;
    [SerializeField] ParticleSystem hitEffect;
    public float GetDamage()
    {
        return damage;
    }
    public void Dead()
    {
        Destroy(gameObject);
        hitEffectFun();
    }
    private void hitEffectFun()
    {
        ParticleSystem instaPartical = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(instaPartical.gameObject, instaPartical.main.duration + instaPartical.main.startLifetime.constantMax);
    }

}
