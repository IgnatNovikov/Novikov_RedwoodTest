using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float _cameraSpeed = .2f;

    [Inject] private ICharacter _characterPosition;

    private void FixedUpdate()
    {
        Vector3 newPos = transform.position;
        newPos.x = Mathf.Lerp(transform.position.x, _characterPosition.GetCameraPosition().x, _cameraSpeed);
        transform.position = newPos;
    }
}
