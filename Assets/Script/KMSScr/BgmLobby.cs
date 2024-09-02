using UnityEngine;
using UnityEngine.SceneManagement;
public class BgmLobby : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name != "LobbyScene_Psy" && scene.name != "IntroScene")
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
