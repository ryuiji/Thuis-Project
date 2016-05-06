using UnityEngine;
using System.Collections;

public class Interact : MonoBehaviour {

    public GameObject weaponLoc;
    public Transform playerCam;

    public void CanInteract(RaycastHit hit) {
        if (hit.transform.tag == "Gun") {
            switch (hit.transform.GetComponent<GunEnum>().weapons) {
                case GunEnum.Weapons.Pistol:
                    break;
                case GunEnum.Weapons.AK:
                    break;
                case GunEnum.Weapons.M4A1:
                    break;
            }
            GetComponent<WeaponHold>().AddWeapon(hit);
            hit.transform.gameObject.SetActive(false);
        }
    }
}
