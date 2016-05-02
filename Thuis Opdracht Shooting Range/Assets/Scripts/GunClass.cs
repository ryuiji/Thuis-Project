using UnityEngine;
using System.Collections;

public abstract class GunClass : MonoBehaviour {

    public string gunName;
    public float fireRate;
    public float curAmmo;
    public float ammoSize;
    public float maxAmmo;
    public GameObject bullet;
    public bool isReloading;
    public bool mayFire = true;

    public abstract void Shooting();

    public abstract void Reload();
}
