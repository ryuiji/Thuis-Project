using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public abstract class GunClass : MonoBehaviour {

    public string gunName;
    public float fireRate;
    public float curAmmo;
    public float maxAmmo;
    public float leftoverAmmo;
    public float ammoToReload;
    public GameObject bullet;
    public float bulletSpeed;
    public WeaponHold weaponHold;
    public Text ammoText;


    public abstract void PassDelegates();

    public abstract void Shooting();

    public abstract void Reload();

    public abstract void AmmoText();
}
