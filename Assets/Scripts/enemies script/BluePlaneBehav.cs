using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BluePlaneBehav : MonoBehaviour
{
    Vector3 pos;
    [SerializeField] float speedPlane;
    [SerializeField] float radius;
    private void Start()
    {
        pos = transform.position;
    }
    void Update()
    {
        transform.position = pos;
        pos.y += Mathf.Sin(pos.x)* radius * Time.deltaTime;
        pos.x -= speedPlane * Time.deltaTime;
        
    }
}
