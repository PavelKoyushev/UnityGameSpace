using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject asteroidExplosion;
    public GameObject playerExplosion;

    public float speed;
    public float rotationSpeed;
    
    Rigidbody asteroid;
    float mult;
    void Start()
    {
        mult = Random.Range(0.5f, 1.5f);

        asteroid = GetComponent<Rigidbody>();
        asteroid.angularVelocity = Random.insideUnitSphere * rotationSpeed;
        asteroid.velocity = new Vector3(0, 0, -speed * mult);
        asteroid.transform.localScale /= mult;
    }

    // срабатывает при столкновении с коллайдером
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Asteroid")
        {
            return;
        }

        if (other.tag == "Grinder")
        {
            return;
        }

        GameObject newExplosion = Instantiate(asteroidExplosion, asteroid.transform.position, Quaternion.identity);
        newExplosion.transform.localScale /= mult;
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, Quaternion.identity);
        }

        Destroy(gameObject); //уничтожает текущий обьект
        Destroy(other.gameObject);
    }
}
