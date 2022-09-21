using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int collectibleValue;
    public GameObject collectedFX;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<ItemManager>().HandleCollectible(collectibleValue);
            StartCoroutine(Collected());
        }
    }

    public IEnumerator Collected()
    {
        this.gameObject.GetComponentInChildren<SpriteRenderer>().sprite = null;
        Instantiate(collectedFX, gameObject.transform.localPosition, Quaternion.identity);
        yield return new WaitForSeconds(0.01f);
        Destroy(gameObject);
    }
}
