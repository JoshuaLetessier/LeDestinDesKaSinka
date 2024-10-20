using UnityEngine;

using System.Collections;

using UnityEngine.UI;

 

public class OptionScript : MonoBehaviour {

 

    public Transform menuPanel;

    Event keyEvent;

    Text buttonText;

    KeyCode newKey;

 

    bool waitingForKey; 

    void Start ()

    {

        //Assign menuPanel to the Panel object in our Canvas

        //Make sure it's not active when the game starts

        //menuPanel = transform.Find("SettingOption");


        waitingForKey = false;

 

        /*iterate through each child of the panel and check

         * the names of each one. Each if statement will

         * set each button's text component to display

         * the name of the key that is associated

         * with each command. Example: the ForwardKey

         * button will display "W" in the middle of it

         */

        for(int i = 0; i < menuPanel.childCount; i++)

        {

            if(menuPanel.GetChild(i).name == "Left")

                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = ControlManager.GM.left.ToString();

            else if(menuPanel.GetChild(i).name == "Right")

                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = ControlManager.GM.right.ToString();

            else if(menuPanel.GetChild(i).name == "Jump")

                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = ControlManager.GM.jump.ToString();
            
            else if (menuPanel.GetChild(i).name == "Escape")

                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = ControlManager.GM.escape.ToString();
        }

    }

 

 

    //void Update ()

   // {

        //Escape key will open or close the panel

        /*if(Input.GetKeyDown(KeyCode.Escape) && !menuPanel.gameObject.activeSelf)

            menuPanel.gameObject.SetActive(true);

        else if(Input.GetKeyDown(KeyCode.Escape) && menuPanel.gameObject.activeSelf)

            menuPanel.gameObject.SetActive(false);*/

    //}

 

    void OnGUI()

    {

        /*keyEvent dictates what key our user presses

         * bt using Event.current to detect the current

         * event

         */

        keyEvent = Event.current;

 

        //Executes if a button gets pressed and

        //the user presses a key

        if(keyEvent.isKey && waitingForKey)

        {

            newKey = keyEvent.keyCode; //Assigns newKey to the key user presses

            waitingForKey = false;

        }

    }

 

    /*Buttons cannot call on Coroutines via OnClick().

     * Instead, we have it call StartAssignment, which will

     * call a coroutine in this script instead, only if we

     * are not already waiting for a key to be pressed.

     */

    public void StartAssignment(string keyName)

    {

        if (!waitingForKey)
        {
            StartCoroutine(AssignKey(keyName));
        }


    }

 

    //Assigns buttonText to the text component of

    //the button that was pressed

    public void SendText(Text text)

    {

        buttonText = text;

    }

 

    //Used for controlling the flow of our below Coroutine

    IEnumerator WaitForKey()

    {

        while(!keyEvent.isKey)
        {
            yield return null;
        }

    }

 

    /*AssignKey takes a keyName as a parameter. The

     * keyName is checked in a switch statement. Each

     * case assigns the command that keyName represents

     * to the new key that the user presses, which is grabbed

     * in the OnGUI() function, above.

     */

    public IEnumerator AssignKey(string keyName)

    {

        waitingForKey = true;

        yield return WaitForKey(); //Executes endlessly until user presses a key



        switch (keyName)

        {


            case "left":

                ControlManager.GM.left = newKey; //set left to new keycode

                buttonText.text = ControlManager.GM.left.ToString(); //set button text to new key

                PlayerPrefs.SetString("Left", ControlManager.GM.left.ToString()); //save new key to playerprefs

                break;

            case "right":

                ControlManager.GM.right = newKey; //set right to new keycode

                buttonText.text = ControlManager.GM.right.ToString(); //set button text to new key

                PlayerPrefs.SetString("Right", ControlManager.GM.right.ToString()); //save new key to playerprefs

                break;

            case "jump":

                ControlManager.GM.jump = newKey; //set jump to new keycode

                buttonText.text = ControlManager.GM.jump.ToString(); //set button text to new key

                PlayerPrefs.SetString("Jump", ControlManager.GM.jump.ToString()); //save new key to playerprefs

                break;

            case "escape":

                ControlManager.GM.escape = newKey; //set jump to new keycode

                buttonText.text = ControlManager.GM.escape.ToString(); //set button text to new key

                PlayerPrefs.SetString("Escape", ControlManager.GM.escape.ToString()); //save new key to playerprefs

                break;


        }

 

        yield return null;

    }

}