using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VehicleDropdown : MonoBehaviour
{

    public TMP_Dropdown dropdown;
    public SpriteRenderer mySprite;

    //This is basically what we did in the reading, I just wanted to add some... flair!

    void Start()
    {
        mySprite.sprite = dropdown.options[0].image; //Default avatar
    }

    public void OnValueChanged(int index) //let's select a cool new character! HEHE ENJOY
    {
        mySprite.sprite = dropdown.options[index].image;
    }
}
