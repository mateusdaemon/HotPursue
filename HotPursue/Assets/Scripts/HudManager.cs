using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HudManager : MonoBehaviour
{
    public static HudManager Instance;
    public TextMeshProUGUI lifeTxt;
    public TextMeshProUGUI goldTxt;
    public TextMeshProUGUI totalGoldTxt;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetGold(int coins)
    {
        goldTxt.text = "Gold:" + coins + "/10";
    }

    public void SetLives(int lives)
    {
        lifeTxt.text = "Lives:" + lives;
    }

    public void SetTotal(int total)
    {
        totalGoldTxt.text = "Total:" + total;
    }


}
