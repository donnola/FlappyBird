using UnityEngine;

namespace Main
{
    public class PipeMove : MonoBehaviour
    {
    
        [SerializeField]
        private float speed;

        void Update()
        {
            transform.position = Vector2.MoveTowards(transform.position, 
                (transform.position - transform.right), speed * Time.deltaTime);
        }
    }
}

