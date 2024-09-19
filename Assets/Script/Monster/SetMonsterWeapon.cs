using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMonsterWeapon : MonoBehaviour
{
    [SerializeField]
    public GameObject WeaponPoint;
    //[SerializeField]
    //public MeshFilter WeaponMeshFilter;
    //[SerializeField]
    //public MeshRenderer WeaponRenderer;

    Transform WeaponLocation;
    private void Awake()
    {
        WeaponLocation = WeaponPoint.transform;
        //transform.position = WeaponLocation.position;
    }
    void Update()
    {
        transform.position = WeaponLocation.position;
        transform.rotation = WeaponLocation.rotation;
    }
}
