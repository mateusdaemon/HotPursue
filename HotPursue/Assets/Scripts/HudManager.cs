using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HudManager : MonoBehaviour
{
    public TextMeshProUGUI lifeTxt;
    public TextMeshProUGUI goldTxt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetGold(int coins)
    {
        goldTxt.text = "Gold: " + coins;
    }

    public void SetLives(int lives)
    {
        lifeTxt.text = "Lives: " + lives;
    }


}
