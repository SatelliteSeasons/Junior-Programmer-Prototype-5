using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private GameManager gameManager;
    public ParticleSystem explosionParticle;

    public float xRange = 4f;
    private float ySpawnPosition = 0;

    private float minForce = 8;
    private float maxForce = 14;
    public float maxTorque = 10;

    public int pointsValues = 1;

    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        this.transform.position = RandomSpawnPosition();

        targetRb.AddForce( RandomForce(), ForceMode.Impulse );
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
    }

    void Update()
    {
        
    }

    public void OnMouseDown() //Méthode déjà crée, qui détecte la souris lorsque celui-ci clique sur notre collider
    {
        if (gameManager.gameActive)
        {
            Instantiate(explosionParticle, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
            gameManager.UpdateScore(pointsValues);
        }
    }

    public void OnTriggerEnter(Collider other) //On a un trigger/collider du nom de "Sensor".gameobject
    {
        Destroy(this.gameObject);
        if( !(this.gameObject.CompareTag("Bad")) )
        {
            gameManager.GameOver();
        }
    }




    public Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minForce, maxForce);
    }

    public Vector3 RandomSpawnPosition()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPosition);
    }

    public float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

}
