using UnityEngine;

public class pipes : MonoBehaviour
{
    float leftEdge;
    public float speed = 5f;
    void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x -1f;
    }    
    void Update()
    {
        if(transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
