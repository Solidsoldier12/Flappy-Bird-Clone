using UnityEngine;
public class player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public float gravity = -9.8f;
    public float strength = 5f;
    private Vector3 direction;
    public Sprite[] playerAnimation;
    int count = 0;
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        InvokeRepeating( "SpriteAnimation", 0.15f, 0.15f);
    }
    void SpriteAnimation()
    {
        
        if(count == playerAnimation.Length)
        {
            count = 0;  
        }
        spriteRenderer.sprite = playerAnimation[count];
        count++;

    }
    void Update()
    {

        if( Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            direction = Vector3.up * strength;
        }
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if( touch.phase == TouchPhase.Began)
            {
                direction = Vector3.up * strength;
            }
        }

        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;

    }
}
