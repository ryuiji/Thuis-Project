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
        Rigidbody bulletShot = bullet.GetComponent<Rigidbody>();

        if (Input.GetButtonDown("Fire1") && curAmmo > 0) {
            curAmmo--;
            Rigidbody newBulletShot = Instantiate(bulletShot, weaponHold.shootLoc.transform.position, weaponHold.shootLoc.transform.rotation) as Rigidbody;
            newBulletShot.GetComponent<Bullet>().BulletSpeed(newBulletShot);
            newBulletShot.GetComponent<Bullet>().BulletHit(newBulletShot);
            }
        AmmoText();
    }

    public override void Reload() {
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
        ammoText.text = "Pistol ammo:" + curAmmo.ToString() + "/" + leftoverAmmo.ToString();
    }
}
