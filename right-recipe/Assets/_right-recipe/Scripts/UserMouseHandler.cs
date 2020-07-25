using System.Collections;
using System.Collections.Generic;
using Scripts;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UserMouseHandler : MonoBehaviour
{
    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;


    PlayerRecipe _playerRecipe;

    void Start()
    {
        //Fetch the Raycaster from the GameObject (the Canvas)
        m_Raycaster = GetComponent<GraphicRaycaster>();
        //Fetch the Event System from the Scene
        m_EventSystem = GetComponent<EventSystem>();
        
        _playerRecipe = MainManager.Store.playerRecipe;
    }
    
    void Update()
    {
        if (MainManager.Store.dragManager.HasDraggedItem)
            CheckForRecipePointerEnter();
        else
            _playerRecipe.state = EPlayerRecipeStates.PointerExit;
    }


    void CheckForRecipePointerEnter()
    {
        //Set up the new Pointer Event
        m_PointerEventData = new PointerEventData(m_EventSystem);
        //Set the Pointer Event Position to that of the mouse position
        m_PointerEventData.position = Input.mousePosition;

        //Create a list of Raycast Results
        List<RaycastResult> results = new List<RaycastResult>();

        //Raycast using the Graphics Raycaster and mouse click position
        m_Raycaster.Raycast(m_PointerEventData, results);

        bool hasPlayerRecipe = false;
        //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
        foreach (RaycastResult result in results)
        {
            if (result.gameObject.CompareTag("PlayerRecipe"))
            {
                hasPlayerRecipe = true;
                break;
            }
        }
        
        if (hasPlayerRecipe)
        {
            _playerRecipe.state = EPlayerRecipeStates.PointerEnter;
        }
        else
        {
            _playerRecipe.state = EPlayerRecipeStates.PointerExit;
        }
        
    }

    
}
