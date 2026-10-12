using UnityEngine;
using UnityEngine.SceneManagement;

public class CompletionDetector : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.CompareTag("Player"))
        {
            switch(GameState.currentLevel)
            {
                // if we are on level one, then switch to level 2
                case 1:
                    GameState.currentLevel = 2;

                    SceneManager.LoadScene("Level-2");

                    break;
                
                // if we are on level two, then set the playerWon state to true and switch back to the start menu 
                case 2:
                    GameState.currentLevel = 3;
                    GameState.playerWon = true;

                    SceneManager.LoadScene("Menu");

                    break;

                // if neither of the above cases is true, then we've reached an unintended state, so restart everything and print a debug message
                default: 
                    GameState.currentLevel = 0;
                    GameState.playerWon = false;

                    Debug.Log("Couldn't load the next scene, wrong game state");
                    SceneManager.LoadScene("Menu");

                    break;
            }
        }
    }
}
