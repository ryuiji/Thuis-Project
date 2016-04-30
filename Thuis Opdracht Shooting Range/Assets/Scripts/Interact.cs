﻿using UnityEngine;
using System.Collections;

public class Interact : MonoBehaviour {

    public void CanInteract(RaycastHit hit) {
        if (hit.transform.tag == "Gun") {
            switch (hit.transform.GetComponent<GunEnum>().weapons) {
                case GunEnum.Weapons.Pistol:
                    print("pistol");
                    break;
                case GunEnum.Weapons.AK:
                    print("AK");
                    break;
                case GunEnum.Weapons.M4A1:
                    print("M4A1");
                    break;
            }
        }
    }
}