using System;
using System.Collections;
using System.Collections.Generic;
using Scripts;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

public enum EPlayerRecipeStates
{
    PointerEnter,
    PointerExit
}

public class PlayerRecipe : MonoBehaviour
{
    public Color pointerEnterColor;
    public Color pointerExitColor;
    public EPlayerRecipeStates state;
    EPlayerRecipeStates _currentState;
    
    [SerializeField] GameObject listContent;
    [SerializeField] GameObject ingredients;
    Image _image;
    
    void Awake()
    {
        _image = gameObject.GetComponent<Image>();
    }

    void Update()
    {
        if (_currentState != state)
        {
            SetBackgroundColor();
            _currentState = state;
        }
    }

    void SetBackgroundColor()
    {
        switch (state)
        {
            case EPlayerRecipeStates.PointerEnter :
                _image.color = pointerEnterColor;
                break;
            case EPlayerRecipeStates.PointerExit :
                _image.color = pointerExitColor;
                break;
        }
    }

    public void AddToRecipeListContent(GameObject ingredient)
    {
        ingredient.transform.SetParent(listContent.transform);
        ingredient.GetComponent<ReorderableListElement>().isDroppableInSpace = true;
        ingredient.GetComponent<DraggableVegetable>().ToggleBorder(true);
    }
    
    public void RemoveFromRecipeListContent(GameObject ingredient)
    {
        ingredient.transform.SetParent(ingredients.transform);
    }
   
}
