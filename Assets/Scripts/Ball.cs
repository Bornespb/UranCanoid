using UnityEngine;

public class Ball : MonoBehaviour {

    //config
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] audios;
    [SerializeField] float randomFactor=10f;
    //state
    Vector2 paddleToBallVector;
    private bool isBallLaunched = false;


    //Cached reference
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2D;

	// Use this for initialization
	void Start (){
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(!isBallLaunched)
            LockBallToPaddle();

        LaunchBallOnMouseClick();
    }

    private void LaunchBallOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
            isBallLaunched = true;
        }
        
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePosition = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddleToBallVector + paddlePosition;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*Vector2 velocityTweak = new Vector2(
            Random.Range(0f, randomFactor),
            Random.Range(randomFactor, 0f));
            */
        float velocityTweak = Random.Range(0f, randomFactor);
        if (isBallLaunched)
        {
            AudioClip clip = audios[Random.Range(0,audios.Length)];
            myAudioSource.PlayOneShot(clip);
            myRigidBody2D.MoveRotation(velocityTweak);
        }
    }
}
