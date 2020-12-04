using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody _rigidBody;
    private float _paddleHalfWidth;
    [SerializeField] private Ball _ball = null;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        _rigidBody = GetComponent<Rigidbody>();
        _paddleHalfWidth = transform.GetComponent<BoxCollider>().bounds.size.x * 0.5f;
    }

    void FixedUpdate()
    {
        Vector2 screenSizeWorldSpace = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0));
        Vector2 clampedPaddlePos = new Vector2(Mathf.Clamp(Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, 0)).x, screenSizeWorldSpace.x * -1 + _paddleHalfWidth, screenSizeWorldSpace.x - _paddleHalfWidth), 0);
        _rigidBody.MovePosition(new Vector3(clampedPaddlePos.x, transform.position.y, 0));
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ball" && _ball._ballInPlay)
        {
            Rigidbody ballRigidBody = collision.gameObject.GetComponent<Rigidbody>();
            float paddleCentreX = this.transform.position.x;
            float ballPaddleHitX = collision.contacts[0].point.x;

            ballRigidBody.velocity = Vector3.zero;

            float difference = paddleCentreX - ballPaddleHitX;

            if (paddleCentreX < ballPaddleHitX)
            {
                ballRigidBody.AddForce(new Vector3((Mathf.Abs(difference * 200)), _ball._ballVelocity, 0));
            }
            else
            {
                ballRigidBody.AddForce(new Vector3(-(Mathf.Abs(difference * 200)), _ball._ballVelocity, 0));
            }
        }
    }
}