using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragScript : MonoBehaviour, IDragHandler, IBeginDragHandler
{
    public Transform _player;

    public PlayerScript PlayerScript;
    public StartMenuScript StartMenuScript;

    public void OnDrag(PointerEventData eventData)
    {
        if (_player.position.x + eventData.delta.x / 200 >= 2.02)
            _player.position = new Vector3(2.02f, _player.position.y, _player.position.z);
        else if (_player.position.x + eventData.delta.x / 200 <= -2.02)
            _player.position = new Vector3(-2.02f, _player.position.y, _player.position.z);
        else
        _player.Translate(eventData.delta.x/200, 0, 0);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        PlayerScript.StartGame();
        StartMenuScript.HideStartMenu();
    }
}
