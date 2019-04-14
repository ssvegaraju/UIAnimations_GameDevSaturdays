using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float moveSpeed = 7f;
    public float bulletSpeed = 15f;
    public float fireRate = 0.1f;

    public Transform spawnPos;
    public GameObject bulletPrefab;

    private Rigidbody rigid;
    private Camera cameron;

	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody>();
        cameron = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"),
            0, Input.GetAxis("Vertical"));
        rigid.MovePosition(transform.position +
            input.normalized * moveSpeed * Time.deltaTime);

        Vector3 playerPos = cameron.WorldToScreenPoint(
            transform.position);
        Vector3 lookDir = Input.mousePosition - playerPos;
        transform.rotation = Quaternion.LookRotation(
            new Vector3(lookDir.x, 0, lookDir.y));

        if (Input.GetButtonDown("Fire1")) {
            Shoot();
        }
	}

    private float lastFireTime;
    void Shoot() {
        if (Time.time - lastFireTime < fireRate)
            return;
        GameObject bullet = Instantiate(bulletPrefab,
            spawnPos.position + transform.forward*0.3f, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().velocity =
            transform.forward * bulletSpeed;

        lastFireTime = Time.time;
        Destroy(bullet, 5);
    }
}
