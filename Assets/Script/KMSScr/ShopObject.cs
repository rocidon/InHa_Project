using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class ShopObject : MonoBehaviour
{
    // Player 위치 참조
    public Transform player;  

    // 탐지 반경
    public float detectionRadius = 5f;
    
    // 여닫이할 패널
    [SerializeField] private GameObject panel;
    private void Start()
    { 
        // 실행시 패널 비활성화
        panel.SetActive(false);

        // 
        FindPlayer(); 
    }
    private void Update()
    {

        // Player와 오브젝트 거리 계산
        float distance = Vector3.Distance(player.position, transform.position);

        // Player와 오브젝트의 거리가 detectionRadius 안에 있고 && X키가 눌렸을 때
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

    // 씬 전환시 Plyer 의 위치를 못 찾는 경우가 있어서 추가
    private void FindPlayer()
    {
        // Player 태그를 가진 오브젝트를 찾고, 오브젝트의 Transform 컴포넌트에 player 변수에 할당
        player = GameObject.FindGameObjectWithTag("Player")?.transform;

        // 찾을 수 없을 때 null 반환
        if (player == null)
        {
            Debug.Log("not found Player");
        }
    }
}
