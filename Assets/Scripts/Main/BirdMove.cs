using UnityEngine;

namespace Main
{
    public class BirdMove : MonoBehaviour
    {
        [SerializeField]
        private float force;

        [SerializeField] private AudioClip m_DieSound;
        [SerializeField] private AudioClip m_WingSound;
        [SerializeField] private AudioClip m_PointSound;

        private GameObject gameObjectSound1;
        private GameObject gameObjectSound2;
        private GameObject gameObjectSound3;

        private AudioSource audioSource1;
        private AudioSource audioSource2;
        private AudioSource audioSource3;

        private new Rigidbody2D rigidbody;
    

        void Awake()
        {
            gameObjectSound1 = new GameObject("Sound", typeof(AudioSource));
            gameObjectSound2 = new GameObject("Sound", typeof(AudioSource));
            gameObjectSound3 = new GameObject("Sound", typeof(AudioSource));
            
            audioSource1 = gameObjectSound1.GetComponent<AudioSource>();
            audioSource2 = gameObjectSound2.GetComponent<AudioSource>();
            audioSource3 = gameObjectSound3.GetComponent<AudioSource>();
            
            audioSource1.volume = 0.4f;
            audioSource2.volume = 0.4f;
            audioSource3.volume = 0.4f;
            
            rigidbody = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && !Game.IsDie)
            {
                audioSource1.pitch = Random.Range(0.9f, 1.1f);
                audioSource1.PlayOneShot(m_WingSound);
                rigidbody.AddForce(Vector2.up * (force - rigidbody.velocity.y), ForceMode2D.Impulse);
            }
            rigidbody.MoveRotation(rigidbody.velocity.y * 2.0F);
        }
    
        void OnCollisionEnter2D (Collision2D collision)
        {
            if (collision.transform.CompareTag("Obstruction"))
            {
                audioSource2.PlayOneShot(m_DieSound);
                Game.die();
            }
        }

        void OnTriggerExit2D (Collider2D other)
        {
            if (other.transform.CompareTag("Point"))
            {
                audioSource3.pitch = Random.Range(0.9f, 1.1f);
                audioSource3.PlayOneShot(m_PointSound);
                Game.get_point();
            }
        }
    }
}


