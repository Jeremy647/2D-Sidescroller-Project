using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public int melons;

    public void HandleCollectible(int collectibleValue)
    {
        melons += collectibleValue;
    }
}
