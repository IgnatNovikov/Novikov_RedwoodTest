using UnityEngine;

public class CharacterPickUpBox : MonoBehaviour
{
    [SerializeField] private Character _character;

    public void AddBullets(int count)
    {
        _character.AddBullets(count);
    }
}
