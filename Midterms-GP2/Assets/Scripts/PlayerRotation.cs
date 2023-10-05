using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public float Range_Detection;
    public float RotationSpeed;

    private Transform Player_Enemy;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (Enemies.Length > 0)
        {
            Player_Enemy = FindClosestEnemy(Enemies);

            if (Vector3.Distance(transform.position, Player_Enemy.position) <= Range_Detection)
            {
                LookRotate();
            }
        }
    }

    public void LookRotate()
    {
        Vector3 Direction = Player_Enemy.position - transform.position;
        Quaternion Rotation = Quaternion.LookRotation(Direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, Rotation, RotationSpeed * Time.deltaTime);
    }

    Transform FindClosestEnemy(GameObject[] Enemies)
    {
        Transform ClosestEnemy = null;
        float ClosestDistance = Mathf.Infinity;

        foreach (GameObject Enemy in Enemies)
        {
            float distance = Vector3.Distance(transform.position, Enemy.transform.position);

            if (distance < ClosestDistance)
            {
                ClosestDistance = distance;
                ClosestEnemy = Enemy.transform;
            }
        }

        return ClosestEnemy;
    }
}
