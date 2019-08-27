using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TurretShooter : MonoBehaviour
{
    public float shootForce;
    public float fireTime = 0.33f;
    public float projectileLifetime = 5f;
    public Transform muzzlePoint;
    public GameObject projectile;
    public bool shoot = true;

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

        if (shoot == true && (timeToFire <= 0f))
        {
            GameObject currProjectile = (GameObject)Instantiate(projectile, muzzlePoint.position, muzzlePoint.rotation);
            currProjectile.GetComponent<Rigidbody>().AddForce(muzzlePoint.up * shootForce);
            Destroy(currProjectile, projectileLifetime);
            timeToFire = fireTime;
        }
    }
}