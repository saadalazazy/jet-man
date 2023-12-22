using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectailSwap : MonoBehaviour
{
    // plane intiolization 
    [SerializeField] float mindeleyTime = 5;
    [SerializeField] float maxdeleyTime = 9;
    float deleyTime;
    float deleyValue = 0;
    int counter = 0;
    // rocket intialization 
    [SerializeField] float deleyTimeRocket;
    float deleyValueRocket = 0;
    // setup for script
    [SerializeField] List<GameObject> bulletPrefabs;
    int randomIndex = 0;
    int randomPointIndex = 0;
    [SerializeField] Transform points;
    // red plane intiolization 
    [SerializeField] float mindeleyTimeRedPlan = 5;
    [SerializeField] float maxdeleyTimeRedPlan = 9;
    float deleyTimeRedPlan;
    float deleyValueRedPlan = 0;
    int counterFourRedPland = 0;
    private void Start()
    {
        deleyTime = maxdeleyTime;
        deleyTimeRedPlan = maxdeleyTimeRedPlan;
    }
    void Update()
    {
        instantiatePlane();
        instantiatRocket();
        instantiateRedPlane();
    }

    private void instantiatRocket()
    {
        //instantiat a rocket
        if (deleyValueRocket >= deleyTimeRocket)
        {
            randomPointIndex = Random.Range(2, 5);
            GameObject projectile = Instantiate(bulletPrefabs[0], points.GetChild(randomPointIndex).position, Quaternion.identity);
            deleyValueRocket = 0;
            Destroy(projectile, 4);
        }
        else
        {
            deleyValueRocket += Time.deltaTime;
        }
    }

    private void instantiatePlane()
    {
        //instantiate a plane
        if (deleyValue >= deleyTime)
        {
            randomIndex = Random.Range(1, bulletPrefabs.Count - 1);
            randomPointIndex = Random.Range(1, 3);
            if (randomIndex == 1)
                randomPointIndex = 0;

            if(counter < 5)
            {
                GameObject projectile = Instantiate(bulletPrefabs[randomIndex], points.GetChild(randomPointIndex).position, Quaternion.identity);
                Destroy(projectile, 5);
            }
            else
            {
                counter = 0;
                GameObject projectile1 = Instantiate(bulletPrefabs[2], points.GetChild(1).position, Quaternion.identity);
                GameObject projectile2 = Instantiate(bulletPrefabs[2], points.GetChild(2).position, Quaternion.identity);
                Destroy(projectile1, 5);
                Destroy(projectile2, 5);
            }
            deleyValue = 0;
            deleyTime = Random.Range(mindeleyTime, maxdeleyTime);
            counter++;
           
        }
        else
        {
            deleyValue += Time.deltaTime;
        }
    }

    private void instantiateRedPlane()
    {
        if (deleyValueRedPlan >= deleyTimeRedPlan)
        {
            randomPointIndex = Random.Range(0, 5);
            if (randomPointIndex == 2)
                randomPointIndex = 1;
            if(counterFourRedPland < 15)
            {
                GameObject projectile = Instantiate(bulletPrefabs[3], points.GetChild(randomPointIndex).position, Quaternion.identity);
                Destroy(projectile, 5);
            }
            else
            {
                GameObject projectile1 = Instantiate(bulletPrefabs[3], points.GetChild(1).position, Quaternion.identity);
                Destroy(projectile1, 5);
                GameObject projectile2 = Instantiate(bulletPrefabs[3], points.GetChild(2).position, Quaternion.identity);
                Destroy(projectile2, 5);
                GameObject projectile3 = Instantiate(bulletPrefabs[3], points.GetChild(3).position, Quaternion.identity);
                Destroy(projectile3, 5);
                GameObject projectile4 = Instantiate(bulletPrefabs[3], points.GetChild(4).position, Quaternion.identity);
                Destroy(projectile4, 5);
                counterFourRedPland = 0;
            }
            deleyValueRedPlan = 0;
            deleyTimeRedPlan = Random.Range(mindeleyTimeRedPlan, maxdeleyTimeRedPlan);
            counterFourRedPland++;
        }
        else
        {
            deleyValueRedPlan += Time.deltaTime;
        }
    }
}
