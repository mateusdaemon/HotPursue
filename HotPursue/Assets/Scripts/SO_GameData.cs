using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

[CreateAssetMenu(fileName = "GameData_New", menuName = "GameData")]

public class SO_GameData : ScriptableObject, ISerializationCallbackReceiver
{
    public int lives = 5;
    public int gold = 0;

    public void OnAfterDeserialize()
    {
        gold = 0;
        lives = 5;
    }

    public void OnBeforeSerialize()
    {
        
    }
}
