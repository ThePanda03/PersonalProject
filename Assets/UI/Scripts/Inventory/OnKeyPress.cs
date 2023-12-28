using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnKeyPress : MonoBehaviour
{
    //GameObj variable 
    public GameObject InventoryMenu;
    //shown or not show bool variable 
    public bool isShown;

    // Start is called before the first frame update
    void Start()
    {
        InventoryMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.I))
        {
            if (isShown)
            {
                Hide();
            }
            else
            {
                Show();
            }
        }
    }
    //sets the bool and visual obj to true 
    public void Show()
    { 
        InventoryMenu.SetActive(true);
        isShown = true;
    }
    //sets the bool and visual obj to false 
    public void Hide()
    {
        InventoryMenu.SetActive(false);
        isShown = false;
    }
}
