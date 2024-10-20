using UnityEngine;
using System.Collections;

public class ControlManager : MonoBehaviour
{

    //Used for singleton
    public static ControlManager GM;

    //Create Keycodes that will be associated with each of our commands.
    //These can be accessed by any other script in our game
    public KeyCode right { get; set; }
    public KeyCode left { get; set; }
    public KeyCode jump { get; set; }
    public KeyCode escape { get; set; }



    void Awake()
    {
        //Singleton pattern
        if (GM == null)
        {
            GM = this;
        }
        else if (GM != this)
        {
            Destroy(gameObject);
        }
        /*Assign each keycode when the game starts.
         * Loads data from PlayerPrefs so if a user quits the game,
         * their bindings are loaded next time. Default values
         * are assigned to each Keycode via the second parameter
         * of the GetString() function
         */
        right = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Right", "D"));
        left = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Left", "Q"));
        jump = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Jump", "Space"));
        escape = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Escape", "Escape"));

    }


}
