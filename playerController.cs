using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(playerMotor))]
public class playerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.1f;
    [SerializeField]
    private float looksensitive = 3f;

    private playerMotor motor;

    void Start()
    {
        motor = GetComponent<playerMotor>();
    }

    private void Update()
    {
        float _xMov = Input.GetAxisRaw("Horizontal");
        float _zMov = Input.GetAxisRaw("Vertical");

        Vector3 _moveHorizontal = transform.right * _xMov;
        Vector3 _moveVertical = transform.forward * _zMov;

        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * speed;

        motor.Move(_velocity);

        float _yRot = Input.GetAxisRaw("Mouse X");

        Vector3 _rotation = new Vector3(0f, _yRot, 0f) * looksensitive;

        motor.Rotation(_rotation);

        float _xRot = Input.GetAxisRaw("Mouse Y");

        Vector3 _cameraRotation = new Vector3(_xRot,0f , 0f) * looksensitive;

        motor.CameraRotation(_cameraRotation);


    }
}
