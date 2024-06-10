using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimasiBerbeda : MonoBehaviour
{
    public GameObject prefab;
    public Vector3[] positions;

    void Start()
    {
        // Iterasi melalui posisi-posisi yang telah ditentukan
        foreach(Vector3 position in positions)
        {
            // Instansiasi prefab
            GameObject obj = Instantiate(prefab, position, Quaternion.identity);

            // Mulai animasi pada objek yang telah diinstansiasi
            obj.GetComponent<Animator>().Play("bottleanimation", 0, Random.value); // Ganti "NamaAnimasi" dengan nama animasi yang sesuai
        }
    }
}
