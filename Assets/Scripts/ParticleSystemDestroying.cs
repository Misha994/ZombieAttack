using UnityEngine;

public class ParticleSystemDestroying : MonoBehaviour
{
    private ParticleSystem particle;

    private void Start()
    {
        particle = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (!particle.isPlaying && particle.particleCount == 0)
        {
            Destroy(gameObject);
        }
    }
}