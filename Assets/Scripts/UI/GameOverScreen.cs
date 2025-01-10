using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Button _button;

    private void Awake()
    {
        _button.onClick.AddListener(Restart);
    }

    public void Show()
    {

    }

    public void Hide()
    {

    }

    private void Restart()
    {

    }
}
