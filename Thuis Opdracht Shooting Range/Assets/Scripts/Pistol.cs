using UnityEngine;
using System.Collections;

public class Pistol : GunClass {

    public override void PassDelegates() {
        weaponHold.shoot = Shooting;
        weaponHold.reload = Reload;
        weaponHold.ammoText = AmmoText;
        AmmoText();
    }
    public void OnEnable() {
        weaponHold.pass = PassDelegates;
    }

    public override void Shooting() {
        if (Input.GetButtonDown("Fire1")) {
            print("Shot with Pistol");
        }
    }

    public override void Reload() {
        print("reloaded Pistol");
    }
    public override void AmmoText() {
        ammoText.text = "Pistol ammo:" + curAmmo.ToString() + "/" + maxAmmo.ToString();
    }
}
