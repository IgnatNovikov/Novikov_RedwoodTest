using UnityEngine;

public class CharacterHurtBox : MonoBehaviour
{
    [SerializeField] private Character _character;

    public void Death()
    {
        _character.Death();
    }
}
