using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UIElements;
using System;

public class RoomUiHandler : MonoBehaviour
{
    private VisualElement root;
    private Button startGameButton;
    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;

        startGameButton = root.Q<Button>("startGameButton");
        startGameButton.RegisterCallback<ClickEvent>(ev => startGame());

    }

    private void startGame()
    {
        NetworkRoomManager.singleton.ServerChangeScene("ExampleGameScene");
    }
}
