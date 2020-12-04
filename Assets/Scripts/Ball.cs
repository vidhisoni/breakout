using UnityEngine;

public class Ball : MonoBehaviour
{
    public float _ballVelocity = 600f;
    public bool _ballInPlay = false;
    private Rigidbody _rigidBody;


    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //_ballVelocity = _rigidBody.velocity.normalized * _ballSpeed;
        if(Input.GetButtonDown("Fire1") && !_ballInPlay)
        {
            _ballInPlay = true;
            transform.parent = null;
            _rigidBody.isKinematic = false;
            _rigidBody.AddForce(new Vector3(0, _ballVelocity, 0));
        }
    }
}
