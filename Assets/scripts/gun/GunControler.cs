using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControler : MonoBehaviour {

    public Transform playersHands;
    public Vector3 handsOffset;
    public Gun startingGun;

    private Gun equippedGun;


    private void Start()
    {
        if (startingGun != null)
            EquipGun(startingGun);
    }
    public void EquipGun(Gun gunToEquip)
    {
        if (equippedGun != null)
            Destroy(equippedGun.gameObject);
        equippedGun = Instantiate(gunToEquip,playersHands.position + handsOffset,playersHands.rotation) as Gun;
        equippedGun.transform.parent = playersHands;
    }

    public void Shoot()
    {
        if (equippedGun != null)
            equippedGun.Shoot();
    }
}
