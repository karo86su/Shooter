using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject Enemy;
    public int amountOfEnemies = 10;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < amountOfEnemies; i++)
        {
            GameObject enemy = Instantiate(Enemy, transform.position, Quaternion.identity);
        }
    }
}
