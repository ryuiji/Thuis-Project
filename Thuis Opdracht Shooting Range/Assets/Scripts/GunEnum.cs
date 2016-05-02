using UnityEngine;
using System.Collections;

public class GunEnum : MonoBehaviour {

    public enum Weapons { Pistol, AK, M4A1 };
    public Weapons weapons;
    public float fireRate;
    public float curAmmo;
    public float maxAmmo;
}
