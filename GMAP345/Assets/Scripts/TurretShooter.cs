using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TurretShooter : MonoBehaviour
{
    public float shootForce;
    public float fireTime;
    public float projectileLifetime = 2f;
    public Transform muzzlePoint;
    public GameObject projectile;


    private float timeToFire;
    // Start is called before the first frame update
    void Start()
    {
        timeToFire = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timeToFire -= Time.deltaTime;
    }

    public void Fire()
    {
        if (timeToFire <= 0f)
        {
            GameObject currProjectile = (GameObject)Instantiate(projectile, muzzlePoint.position, muzzlePoint.rotation);
            currProjectile.GetComponent<Rigidbody>().AddForce(muzzlePoint.up * shootForce);
            Destroy(currProjectile, projectileLifetime);
            timeToFire = fireTime;
        }
    }
}