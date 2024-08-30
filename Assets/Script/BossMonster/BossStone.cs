using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class BossStone : MonoBehaviour
{
    
    bool isGround = false;
    float FallingSpeed = 5.0f;
    float ScaleY;
    float ScaleX;
    [SerializeField] float StoneTimer;
    [SerializeField] float AirTime;
    // Update is called once per frame
    private void Start()
    {
        StoneTimer = 0;
        AirTime = Random.Range(1.5f, 2.5f);
        ScaleY = (transform.localScale.y/2);
        ScaleX = (transform.localScale.x/2);
    }
    void Update()
    {
        if (StoneTimer > AirTime)
        {
            //범위 처리
            if (!isGround)
            {
                transform.Translate(Vector3.down * FallingSpeed * Time.deltaTime);
                FallingSpeed += 0.1f;
            }
        }
        StoneTimer += Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        Vector3 FixPositon = other.transform.position;
        float playerscaley = other.transform.localScale.y / 2;
        float playerscalex = other.transform.localScale.x / 2;
        float MAXDistanceX = playerscalex + ScaleX;
        float MAXDistanceY = playerscaley + ScaleY;

        float DirX = transform.position.x - FixPositon.x;
        float DistanceX = Mathf.Abs(DirX);
        if (other.gameObject.CompareTag("Player"))
        {
            if (isGround)
            {


                if (FixPositon.y >= transform.position.y +MAXDistanceY)
                {
                    Debug.Log("떨어진 낙석위에 있음!");
                    transform.GetChild(0).gameObject.GetComponent<MeshCollider>().enabled = true;
                }
                else
                {
                    FixPosX(other, MAXDistanceY, DistanceX, DirX);
                    Debug.Log("떨어진 낙석에 들어가있음!");
                    transform.GetChild(0).gameObject.GetComponent<MeshCollider>().enabled = false;
                }
            }
            else //낙석 피격
            {
                Debug.Log("낙석에 피격!");
                //FixPosX(other, MAXDistanceY, DistanceX, DirX);
                //데미지 처리
                //PlayerClass player = collsion.gameObject.GetComponent<NormalMonster>();
                //float playerHP = Get playerHP(); <- MAX HP
                //player.takeDamage(playerHP);
            }

        }
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Round"))
        {
            isGround = true;
            transform.position = new Vector3(transform.position.x, FixPositon.y + ScaleY, transform.position.z);
            FallingSpeed = 5.0f;
        }

    }
    void FixPosX(Collider other, float MAXDIS, float DIS, float DirX)
    {
        Vector3 FixPositon = other.transform.position;
        if (DIS <= MAXDIS)
        {
            if (DirX > 0)
            {
                Debug.Log("Back");
                other.transform.position = new Vector3
                    (transform.position.x - (MAXDIS + 0.05f), FixPositon.y, FixPositon.z);
            }
            else
            {
                Debug.Log("Front");
                //other.transform.localPosition
                other.transform.position = new Vector3
                    (transform.position.x + (MAXDIS + 0.05f), FixPositon.y, FixPositon.z);
            }
        }
    }
    public void SetIsGround(bool val)
    {
        isGround = val;
    }
    public bool GetIsGround()
    {
        return isGround;
    }
}
