using UnityEngine;

public class FireRainCollision : MonoBehaviour
{
    public ParticleSystem fireParticleSystem;
    public ParticleSystem rainParticleSystem;

    void Start()
    {
        // Get the ParticleSystem component attached to this GameObject
        fireParticleSystem = GetComponent<ParticleSystem>();
    }

    
    void Update()
    {
        // If it's raining, stop the fire particle system
        if (rainParticleSystem.isEmitting)
        {
            
                fireParticleSystem.Stop();
            
        }
        
    }
}
