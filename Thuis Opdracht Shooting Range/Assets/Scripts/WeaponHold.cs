using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponHold : MonoBehaviour {


    public List<GameObject> weapons = new List<GameObject>();
    public GameObject playerCam;
    public GameObject weaponLoc;
    public delegate void Shoot();
    public Shoot shoot;
    public delegate void Reload();
    public Reload reload;
    public delegate void PassDelegates();
    public PassDelegates pass;
    public delegate void AmmoText();
    public AmmoText ammoText;

	void Update () {
        WeaponHolding();
        ShootInput();
        ReloadInput();
        AmmoTextChange();
    }
	
	public void AddWeapon (RaycastHit hit) {
        weapons.Add(hit.transform.gameObject);
	}
    public void WeaponHolding() {
        if (Input.GetButtonDown("WeaponOne") && weapons.Count >= 1) {
            DeactivateGuns();
            FixPosition(0);
        }
        if (Input.GetButtonDown("WeaponTwo") && weapons.Count >= 2) {
            DeactivateGuns();
            FixPosition(1);
        }
        if (Input.GetButtonDown("WeaponThree") && weapons.Count >= 3) {
            DeactivateGuns();
            FixPosition(2);
        }
    }
    void DeactivateGuns() {
        for(int i = 0; i < weapons.Count; i++) {
            weapons[i].SetActive(false);
        }
    }
    void FixPosition(int weapon) {
        weapons[weapon].transform.SetParent(playerCam.transform);
        weapons[weapon].transform.position = weaponLoc.transform.position;
        weapons[weapon].transform.rotation = weaponLoc.transform.rotation;
        weapons[weapon].SetActive(true);
        pass();
    }
    void ShootInput() {
        if (Input.GetButton("Fire1") && shoot != null) {
            shoot();
        }
    }
    void ReloadInput() {
        if (Input.GetButtonDown("Reload") && reload != null) {
            reload();
        }
    }
    void AmmoTextChange() {
        
    }
}