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

        private GameObject gameObjectWing;
        private GameObject gameObjectDie;
        private GameObject gameObjectPoint;

        private AudioSource audioWing;
        private AudioSource audioDie;
        private AudioSource audioPoint;

        private new Rigidbody2D rigidbody;
    

        void Awake()
        {
            gameObjectWing = new GameObject("SoundWing", typeof(AudioSource));
            gameObjectDie = new GameObject("SoundDie", typeof(AudioSource));
            gameObjectPoint = new GameObject("SoundPoint", typeof(AudioSource));
            
            audioWing = gameObjectWing.GetComponent<AudioSource>();
            audioDie = gameObjectDie.GetComponent<AudioSource>();
            audioPoint = gameObjectPoint.GetComponent<AudioSource>();
            
            audioWing.volume = 0.4f;
            audioDie.volume = 0.4f;
            audioPoint.volume = 0.4f;
            
            rigidbody = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && !Game.IsDie)
            {
                audioWing.pitch = Random.Range(0.9f, 1.1f);
                audioWing.PlayOneShot(m_WingSound);
                rigidbody.AddForce(Vector2.up * (force - rigidbody.velocity.y), ForceMode2D.Impulse);
            }
            rigidbody.MoveRotation(rigidbody.velocity.y * 2.0F);
        }
    
        void OnCollisionEnter2D (Collision2D collision)
        {
            if (collision.transform.CompareTag("Obstruction"))
            {
                audioDie.PlayOneShot(m_DieSound);
                Game.Die();
            }
        }

        void OnTriggerExit2D (Collider2D other)
        {
            if (other.transform.CompareTag("Point"))
            {
                audioPoint.pitch = Random.Range(0.9f, 1.1f);
                audioPoint.PlayOneShot(m_PointSound);
                Game.AddPoint();
            }
        }
    }
}


