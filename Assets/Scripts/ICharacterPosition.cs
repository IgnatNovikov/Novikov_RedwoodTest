using UnityEngine;

public interface ICharacter
{
    public Vector3 GetPosition();
    public Vector3 GetCameraPosition();
    public void Refresh();
}
