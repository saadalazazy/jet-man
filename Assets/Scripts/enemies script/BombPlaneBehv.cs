using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombPlaneBehv : MonoBehaviour
{
    [SerializeField] GameObject BombPrefab;
    bool isShoot = false;
    GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        if (player.transform.position.x >= gameObject.transform.position.x && !isShoot)
        {
            GameObject bomb = Instantiate(BombPrefab, transform.position, Quaternion.identity);
            Destroy(bomb, 5);
            isShoot = true;
        }
    }
}
