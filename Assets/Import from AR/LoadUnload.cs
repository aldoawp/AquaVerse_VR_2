using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadUnload : MonoBehaviour {

    void OnEnable() {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    void OnDisable() {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        // Code to initialize or reset things after a new scene is loaded
    }

    private void OnSceneUnloaded(Scene scene) {
        // Clean up references or reset states before the current scene unloads
    }
}
