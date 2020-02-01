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

    void OnCollisionEnter(Collision collision)
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        particles.Play();
        Collider[] hits;
        hits = Physics.OverlapSphere(transform.position, ExplosionRadius,mask);
        foreach (Collider item in hits)
        {
            item.GetComponent<MoneyMachine>().Health -= Damage;
        }

        gameObject.GetComponent<Collider>().enabled = false;
        Destroy(gameObject, particles.main.duration);

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 4);
    }

}
