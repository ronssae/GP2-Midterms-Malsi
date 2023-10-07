using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerShooter : MonoBehaviour
{
    public Transform SpawnBulletHere; //This is where we spawn the bullet
    public GameObject BulletPrefab; //PreFab of the Bullet
    public GameObject Nozzle; //Nozzle of the Player
    public Material[] Player_Color;
    private int CurrentMaterialIndex = 0; //Color Detection
    public float BulletSpeed; //Speed of the Bullet
    public float FireRate; //Seconds to Shoot
    private float BaseFireRate;

    // Start is called before the first frame update
    void Start()
    {
        BaseFireRate = FireRate;
    }

    // Update is called once per frame
    void Update()
    {
        FireRate -= Time.deltaTime; // Countdowns the Fire Rate
        if (FireRate <= 0)
        {
            GameObject Bullet = Instantiate(BulletPrefab, SpawnBulletHere.position, SpawnBulletHere.rotation);
            Rigidbody BulletRB = Bullet.GetComponent<Rigidbody>();

            BulletRB.AddForce(SpawnBulletHere.forward * BulletSpeed, ForceMode.Impulse);
            FireRate = BaseFireRate;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            CurrentMaterialIndex = (CurrentMaterialIndex + 1) % Player_Color.Length;

            GetComponent<Renderer>().material = Player_Color[CurrentMaterialIndex];

            Material PlayerMaterial = GetComponent<Renderer>().material;

            Renderer BulletColor = BulletPrefab.GetComponent<Renderer>();

            Renderer NozzleColor = Nozzle.GetComponent<Renderer>();

            BulletColor.material = PlayerMaterial;
            NozzleColor.material = PlayerMaterial;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene(1);
        }
    }
}
