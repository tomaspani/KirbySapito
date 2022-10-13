using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PMovement : MonoBehaviour
{
    private Rigidbody _myRB;
    private Camera _mainCamera;

    [Header("Values")]
    [SerializeField] private float _movSpeed;
    [SerializeField] private float _rotSpeed;
    [SerializeField] private float _jumpForce;

    private float _xAxis, _zAxis;

    private Animator _myAnim;
    [SerializeField] private AnimationClip _punchAnimation;
    [SerializeField] private string _xAxisName;
    [SerializeField] private string _zAxisName;

    [SerializeField] private AnimationClip _jumpAnimation;

    [SerializeField] private AnimationClip _shootAnimation;

    private void Awake()
    {
        _myAnim = GetComponentInChildren<Animator>();
        _myRB = GetComponent<Rigidbody>();
        _mainCamera = FindObjectOfType<Camera>();
    }

    private void Update()
    {
        _xAxis = Input.GetAxisRaw("Horizontal");
        _zAxis = Input.GetAxisRaw("Vertical");

        Ray cameraRay = _mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float raylenght;

        if (groundPlane.Raycast(cameraRay, out raylenght))
        {
            Vector3 pointToLook = cameraRay.GetPoint(raylenght);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }

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

        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(crOnShoot());
        }
    }

    private IEnumerator crOnPunch()
    {
        var speed = _movSpeed;
        _movSpeed = 0;
        _myAnim.SetTrigger("onPunch");
        yield return new WaitForSeconds(_punchAnimation.length);
        _myAnim.SetTrigger("onEndPunch");
        _movSpeed = speed;
    }

    private IEnumerator crOnShoot()
    {
        var speed = _movSpeed;
        _movSpeed = 0;
        _myAnim.SetTrigger("onShoot");
        yield return new WaitForSeconds(_shootAnimation.length);
        _myAnim.SetTrigger("onEndShoot");
        _movSpeed = speed;
    }

    private void FixedUpdate()
    {

        Move(_xAxis, _zAxis);
        _myAnim.SetFloat(_xAxisName, _xAxis);
        _myAnim.SetFloat(_zAxisName, _zAxis);

    }

    private void Move(float xAxis, float zAxis)
    {
        //var dir = (transform.right * xAxis + transform.forward * zAxis).normalized;
        Vector3 moveInput = new Vector3(xAxis, 0f, zAxis).normalized;
        //_myRB.MovePosition(transform.position + dir * _movSpeed * Time.fixedDeltaTime);
        _myRB.MovePosition(transform.position + moveInput * _movSpeed * Time.fixedDeltaTime);

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
