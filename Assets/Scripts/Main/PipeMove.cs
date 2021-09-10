using UnityEngine;
using Utils.Pooling;

namespace Main
{
    public class PipeMove : PooledMonoBehaviour
    {
    
        [SerializeField]
        private float speed;
        void Start()
        {
            Vector2 position = transform.position;
            position.y = Random.Range(-1.5F, 2.7F);
            transform.position = position;
            Destroy(gameObject, 8f);
        }
    
        void Update()
        {
            transform.position = Vector2.MoveTowards(transform.position, 
                (transform.position - transform.right), speed * Time.deltaTime);
        }
    }
}

