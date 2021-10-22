using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwervingController : MonoBehaviour
{
    [SerializeField] private float _forwardSpeed = 5f;
    [SerializeField] private float _lerpSpeed = 5f;
    [SerializeField] private float _playerXValue = 2f;
    [SerializeField] private Vector2 _clampValues = new Vector2(-2, 2);
    private Rigidbody _rb;
    private float _newXPos;
    private float _startXPos;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _startXPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Horizontal"))
        {
            _newXPos = Mathf.Clamp(transform.position.x + Input.GetAxisRaw("Horizontal") * _playerXValue, _startXPos + _clampValues.x, _startXPos + _clampValues.y);
        }
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(new Vector3(Mathf.Lerp(transform.position.x, _newXPos, _lerpSpeed * Time.deltaTime), _rb.velocity.y, transform.position.z + _forwardSpeed * Time.deltaTime));
    }
}
