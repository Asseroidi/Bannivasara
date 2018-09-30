using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ShowPanels : MonoBehaviour {

	public GameObject UICanvas;

	public GameObject basicPanel;
	public GameObject playerConfiqPanel;							
	public GameObject friendConfiqPanel;							
	public GameObject blacklistConfiqPanel;							

	private GameObject activePanel;                         
	private MenuObject activePanelMenuObject;
	private EventSystem eventSystem;

	private void SetSelection(GameObject panelToSetSelected)
	{

		activePanel = panelToSetSelected;
		activePanelMenuObject = activePanel.GetComponent<MenuObject>();
		if (activePanelMenuObject != null)
		{
			activePanelMenuObject.SetFirstSelected();
		}
	}

	public void Start()
	{
		SetSelection(basicPanel);
	}

	//Call this function to activate and display the main menu panel during the main menu
	public void ShowBasicMenu()
	{
		basicPanel.SetActive (true);
		SetSelection(basicPanel);
	}

	//Call this function to deactivate and hide the main menu panel during the main menu
	public void HideBasicMenu()
	{
		basicPanel.SetActive (false);
	}

	//Call this function to activate and display the Options panel during the main menu
	public void ShowPlayerConfiqPanel()
	{
		basicPanel.SetActive (false);
		playerConfiqPanel.SetActive(true);
		SetSelection(playerConfiqPanel);
	}

	//Call this function to deactivate and hide the Options panel during the main menu
	public void HidePlayerConfiqPanel()
	{
		playerConfiqPanel.SetActive(false);
		basicPanel.SetActive(true);
		ShowBasicMenu ();
	}

	//Call this function to activate and display the Pause panel during game play
	public void ShowFriendConfiqPanel()
	{
		basicPanel.SetActive (false);
		friendConfiqPanel.SetActive (true);
		SetSelection(friendConfiqPanel);
	}

	//Call this function to deactivate and hide the Pause panel during game play
	public void HideFriendConfiqPanel()
	{
		friendConfiqPanel.SetActive (false);
		basicPanel.SetActive (true);
	}

	//Call this function to activate and display level selection panel during main menu
	public void ShowBlacklistConfiqPanel()
	{
		blacklistConfiqPanel.SetActive (true);
		basicPanel.SetActive(false);
		SetSelection (blacklistConfiqPanel);
	}

	//Call this function to deacticvate and hide level selection panel durin the main menu
	public void HideBlacklistConfiqPanel()
	{
		blacklistConfiqPanel.SetActive (false);
		basicPanel.SetActive(true);
	}
}
