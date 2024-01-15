using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceResetButton : MonoBehaviour
{
    private Renderer buttonRenderer;

    //materials for the colour of the button
    [SerializeField]
    Material idleMaterial;

    [SerializeField]
    Material hoverMaterial;

    bool isClicked;

    //gameObject holding all the dice of this set
    [SerializeField]
    GameObject DiceList;

    // Start is called before the first frame update
    void Start()
    {
        //get renderer component so we can change materials later
        buttonRenderer = gameObject.GetComponent<Renderer>();
        isClicked = false;
    }

    public void onHover()
    {
        //change the color of button while hovering
        //as long as the button hasn't been clicked recently
        if (!isClicked)
        {
            buttonRenderer.material = hoverMaterial;
        }
    }

    public void offHover()
    {
        //return the color to it's original
        buttonRenderer.material = idleMaterial;
    }

    public void buttonClicked()
    {
        //if the button has not been clicked
        if (!isClicked)
        {
            isClicked = true;
            //moves the button down to indicate that it has been pressed
            Vector3 currentPos = gameObject.transform.localPosition;
            currentPos.y = 0.25f;
            gameObject.transform.localPosition = currentPos;

            //call function after 3 seconds to reset dice
            Invoke("resetDiceLocations", 3f);
        }
    }

    //reset's the location of the dice to it's original position
    private void resetDiceLocations()
    {
        //iterate through the children of Dice gameObject
        for(int i = 0; i < DiceList.transform.childCount; i++)
        {
            //Get the child of the Dice child
            Transform child = DiceList.transform.GetChild(i);
            try
            {
                //try to reset the position of the dice
                Transform resetChild = child.transform.GetChild(0);
                //position is relative to it's parent
                resetChild.localPosition = new Vector3(0f, 0f, 0f);
            }
            catch(UnityException e)
            {
                //if fail to reset, throw the error and continue
                throw e;
                //Exception typically occurs when a user is holding a die
                //which we don't really need to care about
            }
        }

        //return the position of the button to it's original
        Vector3 currentPos = gameObject.transform.localPosition;
        currentPos.y = 0.75f;
        gameObject.transform.localPosition = currentPos;

        isClicked = false;
    }
}
