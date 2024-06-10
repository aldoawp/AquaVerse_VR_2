using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class TrashObjectClicked : MonoBehaviour
{
    private Label scoreLabel;
    private VisualElement garbageStatus;
    private VisualElement titleImg;
    public GameObject congratsObject;
    private Label garbageStatusText;
    private Label titleText;
    private int currentScoreLocal = 0; // Variabel lokal untuk menyimpan skor dalam scene ini
    private static int currentScoreGlobal = 0; // Variabel global untuk menyimpan keseluruhan skor

    private bool isClicked = false; // Menyimpan status apakah objek sudah diklik atau belum

    [SerializeField]
    private GameObject uiDocument;

    void Start()
    {
        // PlayerPrefs.DeleteAll();
        if (uiDocument != null)
        {
            VisualElement root = uiDocument.GetComponent<UIDocument>().rootVisualElement;
            scoreLabel = root.Q<Label>("score-value");
            garbageStatus = root.Q<VisualElement>("garbage-status");
            garbageStatusText = garbageStatus.Q<Label>("garbage-status-text");
            titleText = root.Q<Label>("title-text");
            titleImg = root.Q<VisualElement>("title-icon");

            // Periksa status objek apakah sudah diklik sebelumnya
            if (PlayerPrefs.HasKey(gameObject.name))
            {
                isClicked = PlayerPrefs.GetInt(gameObject.name) == 1;
                if (isClicked)
                {
                    gameObject.SetActive(false); // Sembunyikan objek jika sudah diklik sebelumnya
                }
            }

            currentScoreLocal = PlayerPrefs.GetInt("currentScoreLocal"); // Mengambil skor lokal dari PlayerPrefs
            currentScoreGlobal = PlayerPrefs.GetInt("currentScoreGlobal"); // Mengambil skor global dari PlayerPrefs

            // Memperbarui tampilan skor
            scoreLabel.text = currentScoreGlobal.ToString();

            if (currentScoreLocal >= 600)
            {
                if (garbageStatusText != null)
                    garbageStatusText.text = "Sudah Bersih";
                if (garbageStatus != null)
                    garbageStatus.style.backgroundColor = new StyleColor(new Color(78f / 255f, 190f / 255f, 94f / 255f));
            }

            // Memperbarui tampilan gelar berdasarkan skor global
            UpdateTitleText(currentScoreGlobal);
        }
        else
        {
            Debug.LogError("UI Document belum diatur.");
        }
    }

    void OnMouseDown()
    {
        // Menambah skor lokal dan global ketika objek diklik
            if (PlayerPrefs.HasKey("currentScoreGlobal"))
                {
                    currentScoreGlobal = PlayerPrefs.GetInt("currentScoreGlobal");
                    scoreLabel.text = currentScoreGlobal.ToString();
                    currentScoreGlobal += 100; // Menambah skor global
                } else {
                    currentScoreGlobal = 100;
                }

            if (PlayerPrefs.HasKey("currentScoreGlobal"))
            {
                currentScoreLocal = PlayerPrefs.GetInt("currentScoreLocal");
                scoreLabel.text = currentScoreGlobal.ToString();
                currentScoreLocal += 100; // Menambah skor lokal
            } else {
                currentScoreLocal = 100;
            }
            

            Debug.Log("Skor setelah ditambah: " + currentScoreLocal);
            Debug.Log("Skor setelah ditambah (global): " + currentScoreGlobal);

            // Menyimpan skor lokal dan global ke PlayerPrefs
            PlayerPrefs.SetInt("currentScoreLocal", currentScoreLocal);
            PlayerPrefs.SetInt("currentScoreGlobal", currentScoreGlobal);

            // Memperbarui tampilan skor
            scoreLabel.text = currentScoreGlobal.ToString();

            // Menyembunyikan objek dan menandai bahwa objek sudah diklik
            gameObject.SetActive(false);
            isClicked = true;

            // Simpan status klik objek ke PlayerPrefs
            PlayerPrefs.SetInt(gameObject.name, 1);

            // Memperbarui tampilan gelar berdasarkan skor global
            if (currentScoreLocal >= 600)
            {
                if (garbageStatusText != null)
                    garbageStatusText.text = "Sudah Bersih";
                if (garbageStatus != null)
                    garbageStatus.style.backgroundColor = new StyleColor(new Color(78f / 255f, 190f / 255f, 94f / 255f));
                
            }

            if (currentScoreGlobal >= 1800)
    {
        // Menampilkan game object canvas image "Congrats" jika skor mencapai 1800
        // GameObject congratsObject = GameObject.Find("CONGRATS");
        if (congratsObject != null)
        {
            congratsObject.SetActive(true);
        }
        else
        {
            Debug.LogError("Game object 'Congrats' tidak ditemukan.");
        }
    }
            UpdateTitleText(currentScoreGlobal);
        
    }

    // Fungsi untuk memperbarui tampilan gelar berdasarkan skor global
    void UpdateTitleText(int score)
    {
        if (titleText != null)
        {
            if (score >= 600)
            {
                titleText.text = "Ahli Pengumpulan";
                if (titleImg != null)
                {
                    // Load sebuah gambar dari Resources
                    Texture2D newTexture = Resources.Load<Texture2D>("mingcute_star-fill");

                    if (newTexture != null)
                    {
                    // Set gambar baru ke elemen titleImg
                    titleImg.style.backgroundImage = new StyleBackground(newTexture);
                    }
                    else
                    {
                    Debug.LogError("Failed to load the image.");
                    }
                }
            }
                
            if (score >= 1200)
            {
                titleText.text = "Eksplorator Terampil";
                if (titleImg != null)
                {
                    // Load sebuah gambar dari Resources
                    Texture2D newTexture = Resources.Load<Texture2D>("game-icons_fluffy-wing");

                    if (newTexture != null)
                    {
                    // Set gambar baru ke elemen titleImg
                    titleImg.style.backgroundImage = new StyleBackground(newTexture);
                    }
                    else
                    {
                    Debug.LogError("Failed to load the image.");
                    }
                }
            }
                
            if (score >= 1800)
            {
                titleText.text = "Maestro Lautan";
                if (titleImg != null)
                {
                    // Load sebuah gambar dari Resources
                    Texture2D newTexture = Resources.Load<Texture2D>("fluent_crown-24-filled");

                    if (newTexture != null)
                    {
                    // Set gambar baru ke elemen titleImg
                    titleImg.style.backgroundImage = new StyleBackground(newTexture);
                    }
                    else
                    {
                    Debug.LogError("Failed to load the image.");
                    }
                }
            }
                
        }
    }
}
