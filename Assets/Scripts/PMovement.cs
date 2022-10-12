using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PMovement : MonoBehaviour
{
    private Rigidbody _myRB;

    [Header("Values")]
    [SerializeField] private float _movSpeed;
    [SerializeField] private float _rotSpeed;
    [SerializeField] private float _jumpForce;

    private float _xAxis, _zAxis;

    private Animator _myAnim;
    [SerializeField] private AnimationClip _punchAnimation;
    [SerializeField] private string _xAxisName;
    [SerializeField] private string _zAxisName;

    [SerializeField]
    private AnimationClip _jumpAnimation;

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
            StartCoroutine(crOnJump());

            //Jump();
            Debug.Log("salto");
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(crOnPunch());
        }
    }

    private IEnumerator crOnPunch()
    {
        _myAnim.SetTrigger("onPunch");
        yield return new WaitForSeconds(_punchAnimation.length);
        _myAnim.SetTrigger("onEndPunch");
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


    private IEnumerator crOnJump()
    {
        _myAnim.SetTrigger("onJump");
        yield return new WaitForSeconds(_jumpAnimation.length);
        _myAnim.SetTrigger("onEndJump");
    }

}
