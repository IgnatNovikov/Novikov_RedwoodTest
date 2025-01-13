using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _quitButton;

    [Header("Animation Settings")]
    [SerializeField] private Animator _animator;
    [SerializeField] private string _showTriggerName;
    [SerializeField] private string _hideTriggerName;

    [Inject] private IBulletPool _bulletPool;
    [Inject] private IZombiePool _zombiePool;
    [Inject] private ICharacter _character;

    private void Awake()
    {
        _restartButton.onClick.AddListener(Restart);
        _quitButton.onClick.AddListener(Quit);
    }

    public void Show()
    {
        Time.timeScale = 0f;
        _animator.SetTrigger(_showTriggerName);
    }

    public void Hide()
    {
        Time.timeScale = 1f;
        _animator.SetTrigger(_hideTriggerName);
    }

    private void Restart()
    {
        _bulletPool.ClearPool();
        _zombiePool.ClearPool();
        _character.Refresh();

        Hide();
    }

    private void Quit()
    {
        Application.Quit();
    }
}
