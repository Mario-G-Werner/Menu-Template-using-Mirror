using UnityEngine;
using UnityEngine.UIElements;
using Mirror;
using Visibility = UnityEngine.UIElements.Visibility;

public class MenuHandler : MonoBehaviour
{
    private Button quitButton;
    private Button joinMenuButton;
    private Button hostButton;
    private Button joinGameButton;
    private VisualElement root;
    private GroupBox joinGameGroup;
    private TextField adressTextField;
    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;


        joinGameGroup = root.Q<GroupBox>("joinGameGroup");

        adressTextField = root.Q<TextField>("adressTextField");
        adressTextField.RegisterCallback<KeyDownEvent>(ev =>
        {
            NetworkRoomManager.singleton.networkAddress = adressTextField.text;
        });

        hostButton = root.Q<Button>("hostButton");
        hostButton.RegisterCallback<ClickEvent>(ev => startRoom());


        joinMenuButton = root.Q<Button>("joinMenuButton");
        joinMenuButton.RegisterCallback<ClickEvent>(ev => joinMenuButtonHandler());

        joinGameButton = root.Q<Button>("joinGameButton");
        joinGameButton.RegisterCallback<ClickEvent>(ev => joinGame());

        quitButton = root.Q<Button>("quitButton");
        quitButton.RegisterCallback<ClickEvent>(ev => { 
            Application.Quit();
            Debug.Log("Application.Quit called!");
        });
    }

    //Toggle Visibility for Adress Input and Join Button
    private void joinMenuButtonHandler()
    {
        if (joinGameGroup.style.visibility == Visibility.Visible)
        {
            joinGameGroup.style.visibility = Visibility.Hidden;
            return;
        }
        else joinGameGroup.style.visibility = Visibility.Visible;
    }
    //Opens Room
    private void startRoom()
    {
        NetworkRoomManager.singleton.StartHost();
    }
    //Joins Open Rooom with adress localhost
    private void joinGame()
    {
        NetworkRoomManager.singleton.StartClient();
    }

}
