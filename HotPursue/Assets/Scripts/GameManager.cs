using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public SO_GameData gameData;

    private HudManager hudManager;
    private GameObject playerRef;
    private bool playerHurt = false;
    private int feedbackCount = 0;
    private int levelCoins;
    private bool moveLevel = false;

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
        hudManager.SetGold(levelCoins);
        hudManager.SetTotal(gameData.total);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int coins)
    {
        gameData.total += coins;
        levelCoins += coins;

        hudManager.SetGold(levelCoins);
        hudManager.SetTotal(gameData.total);


        if (levelCoins >= 10)
        {
            moveLevel = true;
        }
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

    public void ChangeLevel(string sceneName)
    {
        levelCoins = 0;
        SceneManager.LoadScene(sceneName);
    }

    public bool CanMoveLevel()
    {
        return moveLevel;
    }
}
