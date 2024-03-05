using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem _particle;

    private Rigidbody Rb;
    private GameManager gameManager;

    private float minSpeed = 13f;
    private float maxSpeed = 17f;
    private float maxTorque = 8f;
    private float xRange = 4f;
    private float ySpawnPos = -6f;

    [SerializeField]
    private int points;
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        Rb.AddForce(RandomForce(), ForceMode.Impulse);
        Rb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
    }

    private void Update()
    {
        if (transform.position.y < ySpawnPos)
        {
            Destroy(gameObject);
        }
    }
    private void OnMouseDown()
    {
        Instantiate(_particle, transform.position, _particle.transform.rotation);
        gameManager.scoreUpdate(points);
        Destroy(gameObject);
        if (gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
}
