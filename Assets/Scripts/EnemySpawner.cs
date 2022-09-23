using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject wolf;
    [SerializeField] private PlayerController player;


    private void OnTriggerEnter2D(Collider2D col)
    {
        PlayerController p = col.GetComponent<PlayerController>();
        if (p != null)
        {
            Spawn();
        }
    }

    private void Spawn()
    {

        Vector2 circle = Random.insideUnitCircle * 10;
        Vector3 position = new Vector3(circle.x, circle.y, 0f) + (transform.position);
        Instantiate(wolf, position, Quaternion.identity);
        
    }
}
