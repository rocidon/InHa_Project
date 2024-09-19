using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PotalSceneChange3 : MonoBehaviour
{
    // ��Ż�� �÷��̾�� ��ȣ�ۿ��� �� �ִ� ���� ����
    public float interactionRange = 2f;
    private bool isPlayerInRange = false;

    public CurrencyData currencyData;


    private void Update()
    {
        // �÷��̾ ��Ż ������ ���� ��
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.Z))
        {
            currencyData.silverAmount += currencyData.curSilverAmount;
            currencyData.goldAmount += currencyData.curGoldAmount;

            currencyData.curSilverAmount = 0;
            currencyData.curGoldAmount = 0;

            LoadingSceneController.Instance.LoadScene("BossScene_Psy");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        // �÷��̾ ��Ż�� ������ ������ ��
        if(other.CompareTag("RogueHooded"))
        {
            isPlayerInRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        // �÷��̾ ���� ������ ���� ��
        if (other.CompareTag("RogueHooded"))
        {
            isPlayerInRange = false;
        }
    }

}
