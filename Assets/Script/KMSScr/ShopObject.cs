using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class ShopObject : MonoBehaviour
{
    // Player ��ġ ����
    public Transform player;  

    // Ž�� �ݰ�
    public float detectionRadius = 5f;
    
    // �������� �г�
    [SerializeField] private GameObject panel;
    private void Start()
    { 
        // ����� �г� ��Ȱ��ȭ
        panel.SetActive(false);

        // 
        FindPlayer(); 
    }
    private void Update()
    {

        // Player�� ������Ʈ �Ÿ� ���
        float distance = Vector3.Distance(player.position, transform.position);

        // Player�� ������Ʈ�� �Ÿ��� detectionRadius �ȿ� �ְ� && XŰ�� ������ ��
        if (distance <= detectionRadius )
        {
            if(Input.GetKeyDown(KeyCode.X))
            {
                Debug.Log("pressed the \'X\'");
                Toggle();
            }
        }
        else
        {
            panel.SetActive(false);

        }


    }

    private void Toggle()
    {
        if (panel != null)
        {
            bool isActive = panel.activeSelf;
            panel.SetActive(!isActive);
           // Debug.Log("Success Toggle");

        }
        else
        {
            Debug.Log("Error Toggle");
        }
    }

    // �� ��ȯ�� Plyer �� ��ġ�� �� ã�� ��찡 �־ �߰�
    private void FindPlayer()
    {
        // Player �±׸� ���� ������Ʈ�� ã��, ������Ʈ�� Transform ������Ʈ�� player ������ �Ҵ�
        player = GameObject.FindGameObjectWithTag("Player")?.transform;

        // ã�� �� ���� �� null ��ȯ
        if (player == null)
        {
            Debug.Log("not found Player");
        }
    }
}
