using System;
using System.Collections;
using System.Collections.Generic;
using Scripts;
using UnityEngine;
using UnityEngine.EventSystems;


public class ManagersStore : MonoBehaviour
{
    public DragManager dragManager;
    public PlayerRecipe playerRecipe;


    void Awake()
    {
        MainManager.Store = this;
    }

    
}