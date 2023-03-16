using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    Rigidbody2D _playerRigidbody;

    [SerializeField] private float Distance = 0.75f;
    [SerializeField] private float acceleration = 5.0f;
    [SerializeField] private float jumpPower = 5.0f;

    private void Start()
    {
        Physics2D.queriesStartInColliders = false;
        _playerRigidbody = GetComponent<Rigidbody2D>();
    }



    private void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space) && GroundCheck())
            Jump();

    }

    private void Jump() => _playerRigidbody.velocity = new Vector2(0, jumpPower);

    private void Move()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal");

        if (horizontalMovement > 0)
        {
            _playerRigidbody.velocity = new Vector2(horizontalMovement * acceleration, _playerRigidbody.velocity.y);

            transform.localScale = new Vector3(1, 1, 1);
        }
        if (horizontalMovement < 0)
        {
            _playerRigidbody.velocity = new Vector2(horizontalMovement * acceleration, _playerRigidbody.velocity.y);

            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private bool GroundCheck()
    {
        RaycastHit2D check = Physics2D.Raycast(transform.position, -Vector2.up, Distance);

        if (check.collider != null)
            Debug.Log(check.collider.name);

        return check.collider != null && check.collider.gameObject.tag == "Ground";

    }
}
