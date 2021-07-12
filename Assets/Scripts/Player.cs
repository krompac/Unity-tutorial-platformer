using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform roundCheckTransform;
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private Score _score;

    private Rigidbody _rigidBody;
    private bool _jumpKeyWasPressed;
    private float _horizontalInput;
    private int _superJumpsRemaining;

    private Vector3 _initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello world");
        _rigidBody = GetComponent<Rigidbody>();
        _initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _jumpKeyWasPressed = true;
        }

        _horizontalInput = Input.GetAxis("Horizontal");
    }

    //Fixed update is called once every physics update
    private void FixedUpdate()
    {
        _rigidBody.velocity = new Vector3(_horizontalInput, _rigidBody.velocity.y);

        if (Physics.OverlapSphere(roundCheckTransform.position, 0.1f, playerMask).Length == 0)
        {
            return;
        }

        if (_jumpKeyWasPressed)
        {
            float jumpPower = 5f;

            if (_superJumpsRemaining > 0)
            {
                jumpPower *= 2;
                _superJumpsRemaining--;
            }

            _rigidBody.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
            _jumpKeyWasPressed = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            Debug.Log("Hello there");
            Destroy(other.gameObject);
            _superJumpsRemaining++;
            _score.UpdateScore();
        }
        else if (other.gameObject.layer == 8)
        {
            transform.position = _initialPosition;
        }
    }
}