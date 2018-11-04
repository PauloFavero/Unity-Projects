﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Prototype.NetworkLobby;
using UnityEngine.Networking;

public class NetworkLobbyHook: LobbyHook {

    public override void OnLobbyServerSceneLoadedForPlayer(NetworkManager manager,
                                                           GameObject lobbyPlayer,
                                                           GameObject gamePlayer)
    {
        LobbyPlayer lobby = lobbyPlayer.GetComponent<LobbyPlayer>();
        setupPlayerNet localPlayer = gamePlayer.GetComponent<setupPlayerNet>();

        localPlayer.playerName = lobby.playerName;
        localPlayer.playerColor = lobby.playerColor;

    }
	
}
