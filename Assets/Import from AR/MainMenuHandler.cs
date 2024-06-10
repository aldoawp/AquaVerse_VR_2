using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    public GameObject canvasImage;

    // Nama scene yang ingin dibuka
    public string sceneNameToLoad = "SceneNameHere";

    void Start()
    {
        // Deactivate the canvas image and UI document at the start
        if (canvasImage != null)
        {
            canvasImage.SetActive(false);
        }
    }
    void OnEnable()
    {
        // Dapatkan root visual element dari UIDocument komponen ini
        var rootVisualElement = GetComponent<UIDocument>().rootVisualElement;

        // Cari button dengan nama "start-button" dan tambahkan event listener onClick
        var startButton = rootVisualElement.Q<Button>("start-button");
        var continueButton = rootVisualElement.Q<Button>("continue-button");
        if (startButton != null)
        {
            
            startButton.clicked += OnStartButtonClicked;
        }
        if (continueButton != null)
        {
            continueButton.clicked += OnContinueButtonClicked;
        }
    }

    private void OnDisable()
    {
        // Bersihkan event listener (opsional jika object ini dinonaktifkan)
        var rootVisualElement = GetComponent<UIDocument>().rootVisualElement;
        var startButton = rootVisualElement.Q<Button>("start-button");
        var continueButton = rootVisualElement.Q<Button>("continue-button");
        if (startButton != null)
        {
            // PlayerPrefs.DeleteAll();
            startButton.clicked -= OnStartButtonClicked;
        }
        if (continueButton != null)
        {
            continueButton.clicked -= OnContinueButtonClicked;
        }
    }

    private void OnStartButtonClicked()
    {
        var rootVisualElement = GetComponent<UIDocument>().rootVisualElement;
        var startButton = rootVisualElement.Q<Button>("start-button");
        startButton.style.unityBackgroundImageTintColor = new StyleColor(new Color(0f, 177f / 255f, 222f / 255f));
        canvasImage.SetActive(true);
        PlayerPrefs.DeleteAll();
        // Ganti scene ke scene yang diinginkan
        SceneManager.LoadScene("GameplayLV1");
    }

    private void OnContinueButtonClicked()
    {
        var rootVisualElement = GetComponent<UIDocument>().rootVisualElement;
        var continueButton = rootVisualElement.Q<Button>("continue-button");
        continueButton.style.unityBackgroundImageTintColor = new StyleColor(new Color(0f, 177f / 255f, 222f / 255f));
        canvasImage.SetActive(true);
        // Ganti scene ke scene yang diinginkan
        SceneManager.LoadScene("GameplayLV1");
    }
}
