using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelRestarter : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.Health.Died += OnPlayerDied;
    }

    private void OnDisable()
    {
        _player.Health.Died -= OnPlayerDied;
    }

    private void OnPlayerDied()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
