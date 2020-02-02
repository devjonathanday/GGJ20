using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CIAMeteor : MonoBehaviour
{
    public LayerMask mask;
    public float Damage = 5;
    public float FallSpeed = 10;
    public float ExplosionRadius = 4;
    public ParticleSystem particles;
    public GameObject explosion;
    public bool hit;

    void OnTriggerEnter(Collider collision)
    {
        Collider[] hits;
        hits = Physics.OverlapSphere(transform.position, ExplosionRadius, mask);
        foreach (Collider item in hits)
        {
            MoneyMachine machine = item.GetComponent<MoneyMachine>();
            if (machine != null)
            {
                machine.Health = 0;
                machine.Broken = true;
                continue;
            }

            AgentNavigation agent = item.GetComponent<AgentNavigation>();
            if (agent != null)
            {
                agent.Death();
                continue;
            }
        }

        if (!hit)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            GetComponent<MeshRenderer>().enabled = false;
            StartCoroutine(DeathRoutine());
            hit = true;
            //gameObject.GetComponent<Collider>().enabled = false;
            //Destroy(gameObject, particles.main.duration);
        }
    }

    IEnumerator DeathRoutine()
    {
        for (float i = 0; i < 0.05f; i += Time.deltaTime)
            yield return null;

        Destroy(gameObject);
    }


    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawWireSphere(transform.position, 4);
    //}

}
