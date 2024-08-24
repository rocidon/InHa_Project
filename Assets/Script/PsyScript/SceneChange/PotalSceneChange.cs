using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PotalSceneChange : MonoBehaviour
{
    // 포탈이 플레이어와 상호작용할 수 있는 범위 정의
    public float interactionRange = 2f;
    private bool isPlayerInRange = false;

    private void Update()
    {
        // 플레이어가 포탈 범위에 있을 때
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.Z))
        {
            SceneManager.LoadScene("StageScene1_Psy");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        // 플레이어가 포탈의 범위에 들어왔을 때
        if(other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        // 플레이어가 범위 밖으로 갔을 때
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }

}
