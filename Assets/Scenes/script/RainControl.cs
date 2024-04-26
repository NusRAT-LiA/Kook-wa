using UnityEngine;

public class RainControl : MonoBehaviour
{
    public ParticleSystem rainParticleSystem;
    public AudioSource rainAudioSource;
    public AudioSource lightning;
    private float rainDuration = 10f; // Duration of rain in seconds
    private float timeBetweenRains = 40f;// Delay time in seconds
     private bool isRaining = false;

    private void Start()
    {   
        lightning.Pause();
        rainParticleSystem.Pause();
        StartCoroutine(StartRainAfterDelay());

    }

    private void Update()
    {
        // Check if the rain particle system is emitting particles
        if (!rainParticleSystem.isEmitting)
        {
            // Stop playing the rain sound if the rain particle system stops emitting particles
            rainAudioSource.Stop();
           // lightning.Stop();
        }
    }

    private System.Collections.IEnumerator StartRainAfterDelay()
{
    while (true)
        {  
            // Start rain after delay
            yield return new WaitForSeconds(timeBetweenRains);
            lightning.Play();
            yield return new WaitForSeconds(2);
            StartRain();

            // Wait for rain duration
            yield return new WaitForSeconds(rainDuration);
            StopRain();
        }
}
     private void StartRain()
    {
        // lightning.Play();

        // Start the rain particle system
        rainParticleSystem.Play();
        rainAudioSource.loop= true;

        // Start playing the rain sound
        rainAudioSource.Play();
        lightning.loop = true;

        isRaining = true;
    }

    private void StopRain()
    {
        // Stop the rain particle system
        rainParticleSystem.Stop();

        // Stop playing the rain sound
        rainAudioSource.Stop();
        lightning.Stop();

        isRaining = false;
    }

    public bool IsRaining()
    {
        return isRaining;
    }

}
