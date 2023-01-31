using Mirror;
using UnityEngine;
using UnityEngine.UIElements;

public class RoomUiHandler : MonoBehaviour
{
    private VisualElement root;
    private Button startGameButton;
    private Button quitButton;
    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;

        startGameButton = root.Q<Button>("startGameButton");
        startGameButton.RegisterCallback<ClickEvent>(ev => startGame());

        quitButton = root.Q<Button>("quitButton");
        quitButton.RegisterCallback<ClickEvent>(ev =>
        {

            NetworkRoomManager.singleton.StopClient();
            NetworkRoomManager.singleton.StopHost();
            NetworkRoomManager.singleton.StopServer();

        });

    }

    private void startGame()
    {
        NetworkRoomManager.singleton.ServerChangeScene("ExampleGameScene");
    }
}
