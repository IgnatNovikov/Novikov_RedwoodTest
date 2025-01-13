using UnityEngine;
using Zenject;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float _cameraSpeed = .2f;

    [Inject] private ICharacter _character;

    private void FixedUpdate()
    {
        Vector3 newPos = transform.position;
        newPos.x = Mathf.Lerp(transform.position.x, _character.GetCameraPosition().x, _cameraSpeed);
        transform.position = newPos;
    }
}
