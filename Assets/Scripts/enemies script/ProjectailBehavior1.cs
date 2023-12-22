using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectailBehavior1 : MonoBehaviour
{
    [SerializeField] float speedBullet;
    void Update()
    {
        transform.position -= new Vector3(speedBullet * Time.deltaTime, 0, 0);
    }
}
