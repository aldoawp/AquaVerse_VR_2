using UnityEngine;
using UnityEngine.UI;

public class ButtonVisibilityToggle : MonoBehaviour
{
    public Image imageToDeactivate;

    void Start()
    {
        // Assuming you have already assigned the Image reference in the Unity Editor
        if (imageToDeactivate == null)
        {
            Debug.LogError("Image reference not set in the inspector!");
        }
    }



    public void DeactivateImage()
    {
        // Check if the image reference is valid
        if (imageToDeactivate != null)
        {
            // Deactivate the image
            imageToDeactivate.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("Image reference is null!");
        }
    }
}
