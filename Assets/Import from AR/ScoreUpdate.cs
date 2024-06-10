using UnityEngine;
using UnityEngine.UIElements;

public class ScoreUpdate : MonoBehaviour
{
    private int score = 0; // Nilai awal skor

    // Start is called before the first frame update
    // Start is called before the first frame update
    void Start()
    {
        // Panggil method untuk mencari objek pertama dengan tag "clickable-object"
        FindAndUpdateScore();
    }

    // Method untuk mencari objek dengan tag "clickable-object" dan memperbarui skor
    void FindAndUpdateScore()
    {
       
        GameObject clickableObject = GameObject.Find("clickable-object");
        // Jika objek ditemukan, tambahkan komponen ScoreObject ke objek tersebut
        if (clickableObject != null)
        {
            clickableObject.AddComponent<ScoreObject>().scoreUpdate = this;
        }
        else
        {
            // Jika tidak ada objek lagi, keluar dari method
            return;
        }
    }

    // Method untuk memperbarui skor ketika objek di klik
    public void UpdateScore()
    {
        // Menambahkan 100 pada skor
        score += 100;

        // Menampilkan pesan ke console untuk mengetahui bahwa objek telah diklik
        Debug.Log("Berhasil! Objek telah diklik");

        // Memperbarui teks label skor di UI
        var scoreLabel = GetComponent<UIDocument>().rootVisualElement.Q<Label>("score-value");
        scoreLabel.text = score.ToString();

        // Setelah memperbarui skor, cari objek berikutnya dan perbarui skor lagi
        FindAndUpdateScore();
    }
}

// Class untuk menangani event klik pada objek 3D
public class ScoreObject : MonoBehaviour
{
    public ScoreUpdate scoreUpdate; // Referensi ke skrip ScoreUpdate

    private void OnMouseDown()
    {
        // Memanggil method UpdateScore dari skrip ScoreUpdate saat objek 3D diklik
        scoreUpdate.UpdateScore();

        gameObject.SetActive(false);

    }
}
