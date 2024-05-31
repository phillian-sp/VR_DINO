using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleBurst : MonoBehaviour
{
    public ParticleSystem collisionParticleSystem;
    public SkinnedMeshRenderer smr;
    public bool once = true;

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Collision detected + " + collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Player") && once)
        {
            var em = collisionParticleSystem.emission;
            var dur = collisionParticleSystem.main.duration;

            em.enabled = true;
            collisionParticleSystem.Play();

            once = false;
            Destroy(smr);
            Invoke(nameof(DestroyParticle), dur);
        }
    }
    
    void DestroyParticle()
    {
        Destroy(collisionParticleSystem.gameObject);
    }
}
