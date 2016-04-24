using UnityEngine;
using System.Collections;

public class Moving : MonoBehaviour {

    public float moveSpeed;
    public float walkSpeed = 5;
    public float runSpeed = 10;
    public float yRot;
    public float xRot;
    public float sens = 2.5f;

    public RaycastHit hit;
    private float rayDis = 10f;

    void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

	void FixedUpdate () {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        CameraRot();
        Sprint();
        ButtonInput();

        transform.Translate(hor * moveSpeed * Time.deltaTime, 0, ver * moveSpeed * Time.deltaTime);
    }

    void CameraRot() {
        yRot += Input.GetAxis("Mouse X") * sens;
        xRot -= Input.GetAxis("Mouse Y") * sens;
        xRot = Mathf.Clamp(xRot, -20, 30);
       
        Camera.main.transform.rotation = Quaternion.Euler(xRot, transform.eulerAngles.y, 0f);
        transform.Rotate(0, Input.GetAxis("Mouse X") * sens, 0);
    }
    void Sprint() {
        if (Input.GetButton("sprint")) {
            print("work2");
            moveSpeed = runSpeed;
        } else {
            moveSpeed = walkSpeed;
        }
    }

    void ButtonInput() {
        if (Input.GetButtonDown("Use")) {
            if (Physics.Raycast(Camera.main.transform.position, transform.forward, out hit, rayDis)) {
                CanInteract(hit);
            }
        }
    }
    void CanInteract(RaycastHit hit) {
        if(hit.transform.tag == "Gun") {
            switch (hit.transform.GetComponent<GunEnum>().weapons) {
                case GunEnum.Weapons.Pistol:
                    print("pistol");
                    break;
                case GunEnum.Weapons.AK:
                    print("AK");
                    break;
                case GunEnum.Weapons.M4A1:
                    print("M4A1");
                    break;
            }
        }
    }
}
