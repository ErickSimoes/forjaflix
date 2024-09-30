using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIControl : MonoBehaviour
{

    [SerializeField] private GameObject exitPanel;
    [SerializeField] private GameObject backButton;
    private GameObject previousSelectedGameObject;
    private bool isActive = false;

    void Update()
    {
        // TODO: add suport to joystick
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePanelState();
        }
    }

    private void TogglePanelState()
    {
        isActive = !isActive;
        exitPanel.SetActive(isActive);

        if (isActive)
        {
            previousSelectedGameObject = EventSystem.current.currentSelectedGameObject;
            EventSystem.current.SetSelectedGameObject(backButton);
        }
        else
        {
            EventSystem.current.SetSelectedGameObject(previousSelectedGameObject);
        }
    }

    public void CancelExit()
    {
        TogglePanelState();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
