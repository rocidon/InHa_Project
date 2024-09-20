using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSkip : MonoBehaviour
{
    public string SceneLoad; // Ω∫≈µ«“ æ¿¿« ¿Ã∏ß

    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(SkipScene);
    }

    void SkipScene()
    {
        SceneManager.LoadScene(SceneLoad);
    }
}
