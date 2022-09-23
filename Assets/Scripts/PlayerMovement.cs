using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _myRB;

    [Header("Values")]
    [SerializeField] private float _movSpeed;
    [SerializeField] private float _rotSpeed;
    [SerializeField] private float _jumpForce;
    
    private float _xAxis, _zAxis;

    private Animator _myAnim;
    [SerializeField] private string _onPunchTrigger;
    [SerializeField] private string _onEndPunchTrigger;
    [SerializeField] private AnimationClip _punchAnimation;
    [SerializeField] private string _xAxisName;
    [SerializeField] private string _zAxisName;

    private void Awake()
    {
        _myAnim = GetComponentInChildren<Animator>();
        _myRB = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _xAxis = Input.GetAxisRaw("Horizontal");
        _zAxis = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
            Debug.Log("salto");
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(crOnPunch());
        }
    }

    private IEnumerator crOnPunch()
    {
        _myAnim.SetTrigger(_onPunchTrigger);
        yield return new WaitForSeconds(_punchAnimation.length);
        _myAnim.SetTrigger(_onEndPunchTrigger);
    }

    private void FixedUpdate()
    {

        Move(_xAxis, _zAxis);
        _myAnim.SetFloat(_xAxisName, _xAxis);
        _myAnim.SetFloat(_zAxisName, _zAxis);

    }

    private void Move(float xAxis, float zAxis)
    {
        var dir = (transform.right * xAxis + transform.forward * zAxis).normalized;

        _myRB.MovePosition(transform.position + dir * _movSpeed * Time.fixedDeltaTime);
    }



    private void Jump()
    {
        _myRB.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
    }

}
