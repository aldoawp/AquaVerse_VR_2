using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class LoadingHandler : MonoBehaviour
{
    public GameObject canvasImage;

    void Start()
    {
        // Menonaktifkan gambar kanvas dan dokumen UI pada awal
        if (canvasImage != null)
        {
            canvasImage.SetActive(false);
        }
    }

    void OnEnable()
    {
        // Dapatkan root visual element dari UIDocument komponen ini
        var rootVisualElement = GetComponent<UIDocument>().rootVisualElement;

        // Cari button dengan nama "home-icon" dan tambahkan event listener onClick
        var homeButton = rootVisualElement.Q<Button>("home-icon");
        if (homeButton != null)
        {
            homeButton.clicked += OnHomeButtonClicked;
        }

        // Cari button dengan nama "level-up-button" dan tambahkan event listener onClick
        var levelUpButton = rootVisualElement.Q<Button>("level-up-button");
        if (levelUpButton != null)
        {
            levelUpButton.clicked += OnLevelUpButtonClicked;
        }

        // Cari button dengan nama "level-down-button" dan tambahkan event listener onClick
        var levelDownButton = rootVisualElement.Q<Button>("level-down-button");
        if (levelDownButton != null)
        {
            levelDownButton.clicked += OnLevelDownButtonClicked;
        }
    }

    private void OnHomeButtonClicked()
    {
        // Aktifkan gambar kanvas
        canvasImage.SetActive(true);
        // Ganti scene ke scene "Home"
        SceneManager.LoadScene("Home");
    }

    private void OnLevelUpButtonClicked()
    {
        // Aktifkan gambar kanvas
        canvasImage.SetActive(true);
        // Ganti scene ke scene "LevelUp"
        SceneManager.LoadScene("GameplayLV3");
    }

    private void OnLevelDownButtonClicked()
    {
        // Aktifkan gambar kanvas
        canvasImage.SetActive(true);
        // Ganti scene ke scene "LevelDown"
        SceneManager.LoadScene("GameplayLV2");
    }

    // Pastikan untuk membersihkan event listener jika diperlukan
    // private void OnDisable()
    // {
    //     var rootVisualElement = GetComponent<UIDocument>().rootVisualElement;
    //     var homeButton = rootVisualElement.Q<Button>("home-icon");
    //     if (homeButton != null)
    //     {
    //         homeButton.clicked -= OnHomeButtonClicked;
    //     }

    //     var levelUpButton = rootVisualElement.Q<Button>("level-up-button");
    //     if (levelUpButton != null)
    //     {
    //         levelUpButton.clicked -= OnLevelUpButtonClicked;
    //     }

    //     var levelDownButton = rootVisualElement.Q<Button>("level-down-button");
    //     if (levelDownButton != null)
    //     {
    //         levelDownButton.clicked -= OnLevelDownButtonClicked;
    //     }
    // }
}
