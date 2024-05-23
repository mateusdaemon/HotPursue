using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private GameManager gameManager;
    public int worth;
    public ParticleSystem particle;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(particle, transform.position, particle.transform.rotation);
            gameManager.AddScore(worth);
            Destroy(gameObject);
        }
    }
}
