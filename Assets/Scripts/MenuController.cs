using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void Play()
    {
        GameState.PlayerWon = false;
        SceneManager.LoadScene("Level-1");
    }
}
