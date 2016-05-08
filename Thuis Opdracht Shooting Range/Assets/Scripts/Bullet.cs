using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Bullet : MonoBehaviour {

    public float bulletSpeed;
    public GameObject holeImage;
    public GameObject player;

    void Start () {
        player = GameObject.Find("Player");
	}
	
	public void BulletSpeed (Rigidbody shot) {
        shot.velocity = transform.TransformDirection(new Vector3(transform.position.x, transform.position.y, bulletSpeed));
    }
    public void OnCollisionEnter(Collision shot) {
        if (shot.gameObject.tag == "Target") {
            player.GetComponent<Points>().AddPoints();
            Destroy(shot.gameObject);
        }
        ContactPoint contact = shot.contacts[0];
        Vector3 bulletPos = contact.point;
        Quaternion rot = Quaternion.FromToRotation(Vector3.forward, contact.normal);
        GameObject hole = Instantiate(holeImage, bulletPos, rot) as GameObject;

        Destroy(gameObject);
        Destroy(hole, 3);
    }
}
