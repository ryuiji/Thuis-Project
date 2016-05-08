using UnityEngine;
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
        if (Input.GetButton("Fire1") && curAmmo > 0) {
            StartCoroutine(WaitForShooting(fireRate));
        } else {
            if (Input.GetButtonUp("Fire1") || curAmmo <= 0) {
                StopCoroutine(WaitForShooting(fireRate));
            }
        }
        AmmoText();
    }
    IEnumerator WaitForShooting(float waitTime) {
        Rigidbody bulletShot = bullet.GetComponent<Rigidbody>();
        Rigidbody newBulletShot = Instantiate(bulletShot, weaponHold.shootLoc.transform.position, weaponHold.shootLoc.transform.rotation) as Rigidbody;
        newBulletShot.GetComponent<Bullet>().BulletSpeed(newBulletShot);
        curAmmo--;
        yield return new WaitForSeconds(waitTime);
        Shooting();
        
    }
	
	public override void Reload () {
        if (curAmmo < maxAmmo && leftoverAmmo > 0) {
            ammoToReload = maxAmmo - curAmmo;
            if (ammoToReload <= leftoverAmmo) {
                leftoverAmmo -= ammoToReload;
                curAmmo += ammoToReload;
            } else {
                curAmmo += leftoverAmmo;
                leftoverAmmo = 0;

            }
            ammoToReload = 0;
        }
        AmmoText();
        
	}
    public override void AmmoText() {
        ammoText.text = "AK ammo:" + curAmmo.ToString() + "/" + leftoverAmmo.ToString();
    }
}
