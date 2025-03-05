using UnityEngine;

namespace MyGame
{
    public class FootstepSound : MonoBehaviour
    {
        public AudioSource footstepAudio; // Arrastra aquí el AudioSource
        public AudioClip[] footstepSounds; // Sonidos de pasos
        public Rigidbody rb; // Asigna el Rigidbody en el Inspector
        public float stepInterval = 0.5f; // Tiempo entre pasos
        public float groundCheckDistance = 0.2f; // Distancia del raycast al suelo
        public LayerMask groundLayer; // Capa del suelo

        private float stepTimer;

        void Update()
        {
            // Verificamos si está en el suelo y en movimiento
            if (IsGrounded() && rb.velocity.magnitude > 0.1f)
            {
                stepTimer += Time.deltaTime;
                if (stepTimer >= stepInterval)
                {
                    PlayFootstep();
                    stepTimer = 0f;
                }
            }
            else
            {
                stepTimer = 0f;
            }
        }

        bool IsGrounded()
        {
            // Lanzamos un Raycast desde los pies hacia abajo para verificar el suelo
            return Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer);
        }

        void PlayFootstep()
        {
            Debug.Log("🔊 Reproduciendo sonido de paso: " + footstepAudio.clip);

        }
    }
}



