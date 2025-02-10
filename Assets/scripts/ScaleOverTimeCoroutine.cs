using UnityEngine;
using System.Collections;

public class ScaleOverTimeCoroutine : MonoBehaviour
{
    public Vector3 scaleUp = new Vector3(2f, 2f, 2f);  // Target scale (larger)
    public Vector3 scaleDown = new Vector3(1f, 1f, 1f); // Target scale (smaller)
    public float duration = 2f; // Time in seconds for one scaling phase

    private void Start()
    {
        StartCoroutine(ScaleLoop());
    }

    IEnumerator ScaleLoop()
    {
        while (true) // Infinite loop for continuous scaling
        {
            yield return ScaleObject(scaleUp, duration);  // Scale up
            yield return ScaleObject(scaleDown, duration); // Scale down
        }
    }

    IEnumerator ScaleObject(Vector3 newScale, float time)
    {
        Vector3 startScale = transform.localScale;
        float elapsedTime = 0f;

        while (elapsedTime < time)
        {
            elapsedTime += Time.deltaTime;
            float progress = elapsedTime / time; // 0 to 1 over time

            transform.localScale = Vector3.Lerp(startScale, newScale, progress);
            yield return null; // Wait for the next frame
        }

        transform.localScale = newScale; // Ensure exact final scale
    }
}

