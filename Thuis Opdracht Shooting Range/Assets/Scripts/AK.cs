﻿using UnityEngine;
using System.Collections;
using System;

public class AK : GunClass {

    public override void PassDelegates() {
        weaponHold.shoot = Shooting;
        weaponHold.reload = Reload;
        weaponHold.ammoText = AmmoText;
        AmmoText();
    }
    public void OnEnable() {
        weaponHold.pass = PassDelegates;
        
    }

    public override void Shooting () {
        curAmmo--;
        AmmoText();
	}
	
	public override void Reload () {
        print("reloaded AK");
	}
    public override void AmmoText() {
        ammoText.text = "AK ammo:" + curAmmo.ToString() + "/" + maxAmmo.ToString();
    }
}