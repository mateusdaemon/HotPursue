using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public SO_GameData gameData;

    private HudManager hudManager;

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
        gameData.lives -= damage;
        hudManager.SetLives(gameData.lives);
    }
}
