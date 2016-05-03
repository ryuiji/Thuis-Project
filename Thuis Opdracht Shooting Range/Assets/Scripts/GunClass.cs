using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public abstract class GunClass : MonoBehaviour {

    public string gunName;
    public float fireRate;
    public float curAmmo;
    public float ammoSize;
    public float maxAmmo;
    public GameObject bullet;
    public bool isReloading;
    public bool mayFire = true;
    public WeaponHold weaponHold;
    public Text ammoText;


    public abstract void PassDelegates();

    public abstract void Shooting();

    public abstract void Reload();

    public abstract void AmmoText();
}
