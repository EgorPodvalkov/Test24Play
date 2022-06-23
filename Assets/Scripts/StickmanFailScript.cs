using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickmanFailScript : MonoBehaviour
{
    public GameObject _failMenu;
    public PlayerScript PlayerScript;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Killer"))
        {
            PlayerScript.moved = false;
            _failMenu.SetActive(true);
            Handheld.Vibrate();
        }
    }
}
