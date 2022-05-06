
using UnityEngine;

public class CharacterSwitching : MonoBehaviour
{
    // Start is called before the first frame update
    //setting a var to equal the first selected chaarcter by index
    public int selectedChar= 0;
    void Start()
    {
        selectChar();
    }

    // Update is called once per frame
    void Update()
    {
        int previousChar = selectedChar;
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedChar = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
            selectedChar = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 2)
        {
            selectedChar = 2;
        }
        if (previousChar != selectedChar)
        {
            selectChar();
        }
    }
    void selectChar()
    {   
        //using i to loop over the chaarcters and make sure that only the one that is selected is set to active and the others are not
        int i = 0;
        foreach (Transform character in transform)
        {
            if(i == selectedChar)
            {
                character.gameObject.SetActive(true);
            }
            else
            {
                character.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
