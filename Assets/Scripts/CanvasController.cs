using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public GameObject canvas; // Reference to the Canvas GameObject

    private void Start()
    {
        // Start the coroutine to show the canvas for a limited time
        StartCoroutine(ShowCanvasForTime(2f));
    }

    private System.Collections.IEnumerator ShowCanvasForTime(float duration)
    {
        // Enable the canvas
        canvas.gameObject.SetActive(true);

        // Wait for the specified duration (in seconds)
        yield return new WaitForSeconds(duration);

        // Disable the canvas
        canvas.gameObject.SetActive(false);
    }
}
