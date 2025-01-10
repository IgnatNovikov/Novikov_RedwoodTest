using UnityEngine;

public class CharacterHurtBox : MonoBehaviour
{
    [SerializeField] private CharacterController _character;

    public void Death()
    {
        _character.Death();
    }
}
