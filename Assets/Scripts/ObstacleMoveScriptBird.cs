using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMoveScriptBird : MonoBehaviour
{
    public ParticleSystem collisionParticleSystem1;
    public SkinnedMeshRenderer smr1;
    public bool once1 = true;
    public ParticleSystem collisionParticleSystem2;
    public SkinnedMeshRenderer smr2;
    public bool once2 = true;
    public ParticleSystem collisionParticleSystem3;
    public SkinnedMeshRenderer smr3;
    public bool once3 = true;

    public float speed = 10.0f;
    public float deadZone = -10.0f;
    // [SerializeField] private float speedIncrement = 1f;
    public PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("PlayerMove").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerMovement.isAlive){
            burst();
        }
        transform.position += Vector3.back * speed * Time.deltaTime;

        if (transform.position.z < deadZone)
        {
            Destroy(gameObject);
        }
    }

    private void burst()
    {
        if (once1)
        {
            var em = collisionParticleSystem1.emission;
            var dur1 = collisionParticleSystem1.main.duration;

            em.enabled = true;
            collisionParticleSystem1.Play();

            once1 = false;
            Destroy(smr1);

            Invoke(nameof(DestroyParticle1), dur1);
        }
        if (once2)
        {
            var em = collisionParticleSystem2.emission;
            var dur2 = collisionParticleSystem2.main.duration;

            em.enabled = true;
            collisionParticleSystem2.Play();

            once2 = false;
            Destroy(smr2);
            
            Invoke(nameof(DestroyParticle2), dur2);
        }
        if (once3)
        {
            var em = collisionParticleSystem3.emission;
            var dur3 = collisionParticleSystem3.main.duration;

            em.enabled = true;
            collisionParticleSystem3.Play();

            once3 = false;
            Destroy(smr3);
            
            Invoke(nameof(DestroyParticle3), dur3);
        }
    }

    void DestroyParticle1()
    {
        Destroy(collisionParticleSystem1.gameObject);
    }
    void DestroyParticle2()
    {
        Destroy(collisionParticleSystem2.gameObject);
    }
    void DestroyParticle3()
    {
        Destroy(collisionParticleSystem3.gameObject);
    }
}
