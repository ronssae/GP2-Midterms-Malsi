using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMoveTowards : MonoBehaviour
{
    public Material[] enemyColorMat;
    public float EnemySpeed;
    public Transform Enemy_Player;

    // Start is called before the first frame update
    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();

        int randomMaterialIndex = Random.Range(0, enemyColorMat.Length);
        renderer.material = enemyColorMat[randomMaterialIndex];
    }

    // Update is called once per frame
    void Update()
    {
        GameObject Player = GameObject.FindWithTag("Player Tag");

        Transform MainPlayer = Player.transform;

        transform.position = Vector3.MoveTowards(transform.position, MainPlayer.transform.position, EnemySpeed);

        EnemyRotate();
    }
    
    public void EnemyRotate()
    {
        Vector3 Direction = Enemy_Player.position - transform.position;
        Quaternion Rotation = Quaternion.LookRotation(Direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, Rotation, 1f * Time.deltaTime);
    }
}
