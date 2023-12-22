using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundBehav : MonoBehaviour
{
    Vector3 startPostion;
    [SerializeField] float endPostion;
    [SerializeField] float speed = 0;
    void Start()
    {
        startPostion = transform.position;
    }
    void Update()
    {
        transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
        if (transform.position.x < endPostion)
            transform.position = startPostion;
    }
}
