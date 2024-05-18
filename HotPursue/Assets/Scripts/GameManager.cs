using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public SO_GameData gameData;

    private HudManager hudManager;
    private GameObject playerRef;
    private bool playerHurt = false;
    private int feedbackCount = 0;

    void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        hudManager = FindObjectOfType<HudManager>();
        hudManager.SetLives(gameData.lives);
        hudManager.SetGold(gameData.gold);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int coins)
    {
        gameData.gold += coins;
        hudManager.SetGold(gameData.gold);
    }

    public void Damage(int damage)
    {
        if (!playerHurt)
        {
            Debug.Log("Hurt player");
            gameData.lives -= damage;
            hudManager.SetLives(gameData.lives);
            playerHurt = true;
            Invoke("ResetHurt", 3.0f);
            Invoke("DmgFeedBack", 0);
        }
    }

    private void ResetHurt()
    {
        playerHurt = false;
    }

    private void DmgFeedBack()
    {
        SpriteRenderer sr = playerRef.GetComponent<SpriteRenderer>();

        if (feedbackCount % 2 == 0)
        {
            sr.color = Color.red;
        } else
        {
            sr.color = Color.white;
        }

        feedbackCount++;

        if (!(feedbackCount > 11))
        {
            Invoke("DmgFeedBack", 0.25f);
        } else
        {
            feedbackCount = 0;
        }
    }


}
