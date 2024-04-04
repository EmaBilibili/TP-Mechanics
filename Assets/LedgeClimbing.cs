using UnityEngine;
public class LedgeClimbing : MonoBehaviour
{
    public float climbSpeed = 5f; 
    public Transform climbEndPosition;
    private bool isClimbing = false;
    public Rigidbody2D playerRb;
    void Start()
    {
        playerRb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartClimbing();
            playerRb.isKinematic = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StopClimbing();
            playerRb.isKinematic = false;
        }
    }
    void Update()
    {
        if (isClimbing)
        {
            float verticalInput = Input.GetAxis("Vertical");
            Vector2 climbVelocity = new Vector2(0f, verticalInput * climbSpeed);
            playerRb.velocity = climbVelocity;
            if (verticalInput > 0 && transform.position.y >= climbEndPosition.position.y)
            {
                StopClimbing();
            }
        }
    }
    void StartClimbing()
    {
        isClimbing = true;
    }
    void StopClimbing()
    {
        isClimbing = false;
        playerRb.velocity = Vector2.zero; // Detener cualquier movimiento del jugador
    }
}