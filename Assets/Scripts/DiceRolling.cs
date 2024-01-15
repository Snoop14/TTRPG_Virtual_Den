using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRolling : MonoBehaviour
{
    //private DiceRollingUpdate diceRollingUpdate;

    //this is the object that appears to display the rolled value
    [SerializeField]
    GameObject rolled_Die;

    [SerializeField]
    AudioSource diceClack;

    public bool isRolling;

    //vectors to keep track of if the object is moving
    Vector3 lastPos = new Vector3(-100f, -100f, -100f);
    Vector3 currentPos;

    // Start is called before the first frame update
    void Start()
    {
        //diceRollingUpdate = GetComponent<DiceRollingUpdate>();
        isRolling = false;
    }

    
    //called whenever the object collides with another
    void OnCollisionEnter(Collision collision)
    {
        if (isRolling)
        {
            diceClack.Play();
        }
    }
    
    //runs after the user throws the die
    public IEnumerator whileRolling()
    {
        while (isRolling)
        {
            //wait for five frames to continue
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            //if the dice have stopped moving
            if (checkIfStopped())
            {
                changeText();

                //x and z rotation remain the same, but y must always be on top of the dice
                Quaternion rotation = Quaternion.Euler(0f, gameObject.transform.eulerAngles.y, 0f);

                //create the rolled_Die gameObject above the location of the die that was rolled
                Instantiate(rolled_Die, currentPos, rotation);
                stopRolling();
            }
        }
    }

    public void stopRolling()
    {
        isRolling = false;
    }

    //This function is only called when the object has been released
    public void startRolling()
    {
        isRolling = true;
        StartCoroutine(whileRolling());
    }

    //this function gets the value that was rolled on the die
    private string getRolledNum()
    {
        //each die has children for each of its faces
        //each child is named the number on the face

        //gets the die's first child
        //store it's y value and name in variables
        float topNum = transform.GetChild(0).position.y;
        string topName = transform.GetChild(0).name;

        //iterate through the rest of the die's children
        for (int i = 1; i < gameObject.transform.childCount; i++)
        {
            //store the childs info in a temp variable
            Transform child = transform.GetChild(i);
            //if the y position of the child is greater than the stored value
            if (child.position.y > topNum)
            {
                //that child is the new top
                topNum = child.position.y;
                topName = child.name;
            }
        }
        //return the name of the highest dice child
        return topName;
    }

    //checks if the previous and current position are the same
    private bool checkIfStopped()
    {
        //stores the location of the die in a vector
        currentPos = gameObject.transform.position;
        //when the object stops moving
        if (currentPos == lastPos)
        {
            return true;
        }
        //stores the location the die was at, at the start of the frame
        lastPos = currentPos;
        return false;
    }

    //Changes the text of the textmesh components attached to the rolled_Die's children
    private void changeText()
    {
        //store the name that was rolled
        string topName = getRolledNum();

        //gets all the textMesh components in the children of the rolled_Die gameObject
        Component[] rolledText = rolled_Die.GetComponentsInChildren<TextMesh>();

        //gets the colour of the gameObject(dice)
        Color changeColour = gameObject.GetComponent<Renderer>().material.color;

        //change the text in each of those childrens textMesh's
        foreach (TextMesh numText in rolledText)
        {
            //change text to the name of the face that was rolled
            numText.text = topName;
            //change colour to match the colour of the die
            numText.color = changeColour;
        }
    }
}
