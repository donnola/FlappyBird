using UnityEngine;

namespace Main
{
    public class BirdMove : MonoBehaviour
    {
        [SerializeField]
        private float force;

        private new Rigidbody2D rigidbody;
    

        void Awake()
        {
            rigidbody = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && !Game.IsDie)
            {
                rigidbody.AddForce(Vector2.up * (force - rigidbody.velocity.y), ForceMode2D.Impulse);
            }
            rigidbody.MoveRotation(rigidbody.velocity.y * 2.0F);
        }
    
        void OnCollisionEnter2D (Collision2D collision)
        {
            if (collision.transform.CompareTag("Obstruction"))
            {
                Game.die();
            }
        }

        void OnTriggerExit2D (Collider2D other)
        {
            if (other.transform.CompareTag("Point"))
            {
                Game.get_point();
            }
        }
    }
}


