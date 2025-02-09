using UnityEngine;
using System.Collections;

public class ScaleOverTimeCoroutine : MonoBehaviour
{
    public Vector3 targetScale = new Vector3(2f, 2f, 2f); // Target size
    public float duration = 2f; // Time in seconds


    private void Start()
    {
        StartCoroutine(ScaleObject(targetScale, duration));
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

        transform.localScale = newScale; // Ensure final scale is exact
    }
}
