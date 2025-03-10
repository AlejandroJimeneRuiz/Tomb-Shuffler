using UnityEngine;

public class FootstepsSound : MonoBehaviour
{
    public AudioSource footstepsAudio;
    public Rigidbody rb;

    void Update()
    {
        if (rb != null && rb.velocity.magnitude > 0.1f)
        {
            if (!footstepsAudio.isPlaying)
            {
                footstepsAudio.Play();
            }
        }
        else
        {
            footstepsAudio.Stop();
        }
    }
}






