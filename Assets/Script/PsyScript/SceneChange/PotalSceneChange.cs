using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PotalSceneChange : MonoBehaviour
{
    // ��Ż�� �÷��̾�� ��ȣ�ۿ��� �� �ִ� ���� ����
    public float interactionRange = 2f;
    private bool isPlayerInRange = false;

    private void Update()
    {
        // �÷��̾ ��Ż ������ ���� ��
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.Z))
        {
            SceneManager.LoadScene("StageScene1_Psy");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        // �÷��̾ ��Ż�� ������ ������ ��
        if(other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        // �÷��̾ ���� ������ ���� ��
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }

}
