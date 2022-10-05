using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public TextMeshProUGUI melonsText;

    public int melonsCount;
    public int mostMelonsCount;

    public void Update()
    {
        melonsText.text = "" + melonsCount;
    }

    public void HandleCollectible(int collectibleValue)
    {
        melonsCount += collectibleValue;
    }
}
