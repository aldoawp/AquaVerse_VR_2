using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TrashHandler : MonoBehaviour
{
    private void OnEnable()
    {
        GetComponent<XRGrabInteractable>().onSelectEnter.AddListener(OnGrab);
    }

    private void OnDisable()
    {
        GetComponent<XRGrabInteractable>().onSelectEnter.RemoveListener(OnGrab);
    }

    private void OnGrab(XRBaseInteractor interactor)
    {
        // Increment the score
        if (ScoreManager.instance != null)
        {
            ScoreManager.instance.AddScore(1);
        }

        // Destroy the trash object
        Destroy(gameObject);
    }
}
