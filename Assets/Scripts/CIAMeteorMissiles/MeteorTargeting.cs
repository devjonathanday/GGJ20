using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorTargeting : MonoBehaviour
{
    public float SpawnHight = 50;
    public GameObject Meteor;
    public Vector2 FieldSize;
    public float SpawnRate = 10;
    public float spawnDecay;
    public float minimumSpawnRate;
    float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= SpawnRate)
        {
            Instantiate(Meteor,
                new Vector3(
                            Random.Range(-FieldSize.x/2, FieldSize.x/2),
                            SpawnHight,
                            Random.Range(-FieldSize.y / 2, FieldSize.y / 2)
                           ),
                        this.transform.rotation);
            timer = 0;
        }
    }

    private void FixedUpdate()
    {
        if (SpawnRate > minimumSpawnRate)
        {
            SpawnRate /= spawnDecay;
        }
    }
}
