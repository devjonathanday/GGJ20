using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorTargeting : MonoBehaviour
{
    public float SpawnHight = 50;
    public GameObject Meteor;
    public Vector2 FieldSize;
    public float SpawnRate = 10;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
}
