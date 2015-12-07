using UnityEngine;
using System.Collections;

public class OrbitCamera : MonoBehaviour
{

    public float _distanceToCenter = 3f;
	public float _sensitivity = 20f;

	private float _currentRotationAroundRight = 0f;
	private float _currentRotationAroundUp = 0f;

	void Start()
	{
		//transform.position = Vector3.back * _distanceToCenter;
		Rotate (_currentRotationAroundRight, _currentRotationAroundUp);
	}

    void Update()
    {
        if (Input.GetMouseButton(0)) {
			_currentRotationAroundRight -= Input.GetAxis("Mouse Y") * _sensitivity;
			_currentRotationAroundUp += Input.GetAxis("Mouse X") * _sensitivity;
			Rotate(_currentRotationAroundRight, _currentRotationAroundUp);
		}
    }

    void Rotate(float degreesAroundRight, float degreesAroundUp)
    {
        Quaternion rotation = Quaternion.Euler(degreesAroundRight, degreesAroundUp, 0f);
        transform.rotation = rotation;
        Vector3 percheASelfie = new Vector3(0f, 0f, -_distanceToCenter);
        transform.position = rotation * percheASelfie;
    }
}
