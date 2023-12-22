using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPlaneBehav : MonoBehaviour
{
    [SerializeField] float speedPlane;
    [SerializeField] float maxSpeedPlane;
    [SerializeField] float maxDestant;
    float timeForRotate;
    [SerializeField] Animator anim;
    [SerializeField] GameObject followBullet;
    bool isShoot = false;
    void Update()
    {
        if (timeForRotate < maxDestant)
        {
            transform.position -= new Vector3(speedPlane * Time.deltaTime, 0, 0);
        }
        else if (timeForRotate > maxDestant + 1)
        {
            transform.position += new Vector3(maxSpeedPlane * Time.deltaTime, 0, 0);
        }
        else
        {
            anim.SetBool("planeRotate" , true);
            if(isShoot == false)
            {
                GameObject projectile = Instantiate(followBullet, transform.position, Quaternion.identity);
                Destroy(projectile, 4);
                isShoot = true;
            }
        }
        timeForRotate += Time.deltaTime;
    }
}
