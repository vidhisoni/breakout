using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    private static GameManager _gameManagerInstance;
    public static GameManager gmInstance => _gameManagerInstance;

    private void Awake()
    {
        if(_gameManagerInstance != null)
        {
            Destroy(_gameManagerInstance);
        }
        else
        {
            _gameManagerInstance = this;
        }
    }
    #endregion

    //private bool _isGameStarted = false;
}
