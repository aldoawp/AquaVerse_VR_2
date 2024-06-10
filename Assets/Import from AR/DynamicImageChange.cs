using UnityEngine;
using UnityEngine.UIElements;

public class DynamicImageChange : MonoBehaviour
{
    void Start()
    {
        // Dapatkan root visual element dari UIDocument komponen ini
        var rootVisualElement = GetComponent<UIDocument>().rootVisualElement;

        // Dapatkan elemen VisualElement dengan nama "logo-img"
        var visualElement = rootVisualElement.Q<VisualElement>("logo-img");

        if (visualElement != null)
        {
            // Load sebuah gambar dari Resources
            Texture2D newTexture = Resources.Load<Texture2D>("mingcute_star-fill");

            if (newTexture != null)
            {
                // Set gambar baru ke elemen VisualElement
                visualElement.style.backgroundImage = new StyleBackground(newTexture);
            }
            else
            {
                Debug.LogError("Failed to load the image.");
            }
        }
    }
}
