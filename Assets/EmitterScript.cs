using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitterScript : MonoBehaviour
{

    public GameObject asteroid;
    public float minDelay, maxdelay; //задержка м/у запусками

    float nextLaunchTime = 0;



    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextLaunchTime)
        {
            Vector3 asteroidPosition = new Vector3(
                Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2),
                0,
                transform.position.z
           );

            Instantiate(asteroid, asteroidPosition, Quaternion.identity);
            nextLaunchTime = Time.time + Random.Range(minDelay, maxdelay);
        }
    }
}
