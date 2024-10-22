using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;

public class Menu_Code : MonoBehaviour
{
    // Array to hold the buttons
    public Interactable[] toggleButtons;

    // Set up design variables
    private int designNumber;

    [Header("Eye Socket Design")]
    public GameObject design_ES;
    [Header("Near Eye Blocks Design")]
    public GameObject design_NEB;

    [Header("Extended Blocks Design")]
    public GameObject design_EB;
    [Header("Blocks on Table Design")]
    public GameObject design_BT;


    void Start()
    {
        HideAllDesigns();
        designNumber = 0;

        foreach (var button in toggleButtons)
        {
            // Add listener to each button's OnClick event
            button.OnClick.AddListener(() => OnButtonClicked(button));
        }
    }

    void Update()
    {
        DisplayDesign(designNumber);
    }

    private void OnButtonClicked(Interactable clickedButton)
    {
        // Determine which button was clicked and set the design number
        for (int i = 0; i < toggleButtons.Length; i++)
        {
            if (toggleButtons[i] == clickedButton)
            {
                designNumber = i + 1; // Assuming design numbers correspond to button indices + 1
                break;
            }
        }

        // Iterate through all buttons
        foreach (var button in toggleButtons)
        {
            // Turn off all buttons except the clicked one
            if (button != clickedButton)
            {
                button.IsToggled = false;
            }
            else
            {
                button.IsToggled = true;
            }
        }

        // Update design display
        ChooseDesign(designNumber);
    }

    public void ChooseDesign(int design)
    {
        HideAllDesigns();
        designNumber = design;
    }

    public void DisplayDesign(int design)
    {
        switch (design)
        {

            case 1:
                design_ES.SetActive(true);
                break;
            case 2:
                design_NEB.SetActive(true);
                break;
            case 3:
                design_EB.SetActive(true);
                break;
            case 4:
                design_BT.SetActive(true);
                break;
        }
    }

    public void HideAllDesigns()
    {
        design_ES.SetActive(false);
        design_NEB.SetActive(false);
        design_EB.SetActive(false);
        design_BT.SetActive(false);

    }
}
