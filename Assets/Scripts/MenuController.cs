using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour
{
    public TMP_Text titleText;
    public TMP_Text buttonText;

    void Awake()
    {
        // if we are showing the start menu (level 0), then keep the default text
        if (GameState.currentLevel == 0)
        {
            titleText.text = "Night Shift";
            buttonText.text = "Play";
        }

        // if we are showing the game over menu (level 3), then the button should say "Play Again" and the title should indicate win/lose
        if (GameState.currentLevel == 3)
        {
            buttonText.text = "Play Again";

            if (GameState.playerWon)
            {
                titleText.text = "You Won!";
            }
            else
            {
                titleText.text = "You Lost!";
            }
        } 
    }

    // when the play button is pressed, reset the win state and level and load level 1
    public void Play()
    {
        GameState.playerWon = false;
        GameState.currentLevel = 1;

        SceneManager.LoadScene("Level-1");
    }
}
