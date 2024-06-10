using UnityEngine;
using UnityEngine.UI;

public class ActivateImageOn3DObjectClick : MonoBehaviour
{
    public GameObject canvasImage;

    void Start()
    {
        // Deactivate the canvas image and UI document at the start
        if (canvasImage != null)
        {
            canvasImage.SetActive(false);
        }
    }

    void OnMouseDown()
    {
        // Check if the canvas image reference is valid
        if (canvasImage != null)
        {
            // Activate the canvas image
            canvasImage.SetActive(true);

            // Check if the UI document reference is valid
        
        }
        else
        {
            Debug.LogError("Canvas Image reference is null!");
        }
    }
}
