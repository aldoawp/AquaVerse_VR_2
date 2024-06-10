using UnityEngine;

public class VideoOpacity : MonoBehaviour
{
    public Material videoMaterial; // Material yang diatur di Inspector

    void Start()
    {
        if(videoMaterial != null)
        {
            Color color = videoMaterial.color;
            color.a = 0.5f; // Set opacity ke 50%
            videoMaterial.color = color;
        }
    }
}
