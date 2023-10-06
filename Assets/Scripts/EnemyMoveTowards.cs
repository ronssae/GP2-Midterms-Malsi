using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMoveTowards : MonoBehaviour
{
    public Material[] EnemyColorMat;
    public float EnemySpeed;

    // Start is called before the first frame update
    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();

        int RandomMaterialIndex = Random.Range(0, EnemyColorMat.Length);
        renderer.material = EnemyColorMat[RandomMaterialIndex];
    }

    // Update is called once per frame
    void Update()
    {
        GameObject Player = GameObject.FindWithTag("Player Tag");

        Transform MainPlayer = Player.transform;

        transform.position = Vector3.MoveTowards(transform.position, MainPlayer.transform.position, EnemySpeed);

    }
}
