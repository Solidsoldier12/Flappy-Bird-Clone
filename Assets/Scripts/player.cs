using UnityEngine;
using System.Collections;
public class player : MonoBehaviour
{
    [SerializeField]
    GameObject gameManager;
    private SpriteRenderer spriteRenderer;
    public float gravity = -9.8f;
    public float strength = 5f;
    private Vector3 direction;
    public Sprite[] playerAnimation;
    int count = 0;
    public float tilt = 5f;
    public AudioSource audioSource1;
    public AudioSource audioSource2;

    //Getting the reference to the audio clips
    //Here you may create as many references with appropriate names as you wish
    //depending on the number of audio clips being used in the game
    public AudioClip wingFlap;
    public AudioClip score;

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
    void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }
     
    void Update()
    {

        if( Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            audioSource1.clip = wingFlap;
            audioSource1.Play();

            direction = Vector3.up * strength;
        }
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if( touch.phase == TouchPhase.Began)
            {
                audioSource1.clip = wingFlap;
                audioSource1.Play();
            
                direction = Vector3.up * strength;
            }
        }

        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;

        //Tilting the Bird on movement
        Vector3 rotation = transform.eulerAngles;
        rotation.z = direction.y * tilt;
        transform.eulerAngles = rotation;

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.gameObject.CompareTag("Obstacle"))
        {
            gameManager.GetComponent<GameManager>().GameOver();
        }
        else if(other.gameObject.CompareTag("Scoring"))
        {
            audioSource2.clip = score;
            audioSource2.Play();
            
            gameManager.GetComponent<GameManager>().IncreaseScore();
        }
    }
}
