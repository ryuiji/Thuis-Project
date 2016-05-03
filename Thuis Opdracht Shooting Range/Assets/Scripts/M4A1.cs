using UnityEngine;
using System.Collections;

public class M4A1 : GunClass {

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
        print("Shot with M4A1");
    }

    public override void Reload() {
        print("reloaded M4A1");
    }
    public override void AmmoText() {
        ammoText.text = "M4A1 ammo:" + curAmmo.ToString() + "/" + maxAmmo.ToString();
    }
}
