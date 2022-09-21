using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevelTrigger : MonoBehaviour
{
    public GameObject finishScreen;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            finishScreen.SetActive(true);
        }
    }
}
