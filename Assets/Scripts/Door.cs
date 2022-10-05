using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Positions
    public Vector3 closePosition;
    public Vector3 openPosition;

    // Timing
    public float duration = 1.2f;

    // Start is called before the first frame update
    void Start()
    {
        closePosition = transform.position;
    }

    public void OpenDoor()
    {
        StartCoroutine(Co_OpenDoor());
    }

    IEnumerator Co_OpenDoor()
    {
        print("open door");
        // this is the method variable we use to track the progress of the lerp
        float timeElapsed = 0f;

        while (timeElapsed < duration)
        {
            transform.position = Vector3.Lerp(closePosition,closePosition + openPosition, timeElapsed / duration);
            timeElapsed += Time.deltaTime;

            // This tells the coroutine to run the while loop again
            yield return null;
        }

        // once we're done with the loop, we force the final position just in case
        transform.position = closePosition + openPosition;
    }
}
