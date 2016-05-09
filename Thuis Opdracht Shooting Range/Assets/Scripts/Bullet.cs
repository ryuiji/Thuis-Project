using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Bullet : MonoBehaviour {

    public float bulletSpeed;
    public GameObject holeImage;
    public GameObject player;
    public RaycastHit hit;
    public float rayDis;
	
	public void BulletSpeed (Rigidbody shot) {
        shot.velocity = transform.TransformDirection(new Vector3(transform.position.x, transform.position.y, bulletSpeed));
    }
    public void BulletHit(Rigidbody bullet) {
        if (Physics.Raycast(bullet.transform.position, bullet.transform.forward, out hit, rayDis)) {
            if (hit.transform.tag == "Target") {
                player = GameObject.Find("Player");
                player.GetComponent<Points>().AddPoints();
                Destroy(bullet.gameObject);
                }
            Vector3 bulletPos = hit.point;
            Quaternion rot = Quaternion.FromToRotation(Vector3.forward, hit.normal);
            GameObject hole = Instantiate(holeImage, bulletPos, rot) as GameObject;

            Destroy(gameObject);
            Destroy(hole, 3);
            }
        }
}
