using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody _rigidbody;
    [SerializeField]
    float forwardSpeed = 1f;
    [Space]
    [SerializeField]
    float angularSpeed = 1f;
    Vector2 initialPos;
    Vector2 currentPos;
    [Space] 
    [SerializeField]
    float speed = 1f;
    [SerializeField] float topSpeed = 20f;
    public static bool isGameStarted = false;

    private void Start()
    {
        _rigidbody=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isGameStarted)
        {
            Movement();
        }
    }
    void Movement()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            _rigidbody.angularVelocity = new Vector3(0f, horizontalInput * angularSpeed, 0f);
            _rigidbody.velocity = transform.forward * verticalInput * forwardSpeed;
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                initialPos = Input.mousePosition;
            }
            if (Input.GetMouseButtonUp(0))
            {
                initialPos = Input.mousePosition;
            }
            if (Input.GetMouseButton(0) )
            {
                currentPos = Input.mousePosition;
                Vector2 deltaPos = (currentPos - initialPos).normalized * speed;
                transform.LookAt(new Vector3(transform.position.x + deltaPos.x, transform.position.y, transform.position.z + deltaPos.y));
                _rigidbody.AddForce(deltaPos.x, 0f,deltaPos.y, ForceMode.Acceleration);
                if (_rigidbody.velocity.magnitude > topSpeed)
                {_rigidbody.velocity = _rigidbody.velocity.normalized * topSpeed; }
            }
        }
#endif
    }

}
