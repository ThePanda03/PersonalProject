using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnKeyPress : MonoBehaviour
{
    public GameObject InventoryMenu;
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

    public void Show()
    { 
        InventoryMenu.SetActive(true);
        isShown = true;
    }

    public void Hide()
    {
        InventoryMenu.SetActive(false);
        isShown = false;
    }
}
