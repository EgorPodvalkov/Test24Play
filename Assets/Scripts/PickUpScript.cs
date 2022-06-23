using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    public GameObject _cube;
    public GameObject _text;

    private Transform Player;
    private Transform Stickman;
    private PlayerScript PlayerScript;
    private AnimatorScript Anim;
    
    public void Start()
    {
        Player = GameObject.Find("Player").GetComponent<Transform>();
        Stickman = Player.Find("Stickman");
        PlayerScript = Player.GetComponent<PlayerScript>();
        Anim = Stickman.GetComponent<AnimatorScript>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.collider.CompareTag("PickUp"))
        {
            Destroy(collision.gameObject);
            PlayerScript.CubeCount++;
            PlayerScript.MainCube=Instantiate(_cube, new Vector3(transform.position.x, PlayerScript.MainCube.transform.position.y + 1, transform.position.z), transform.rotation, Player);
            Instantiate(_text, new Vector3(transform.position.x, PlayerScript.MainCube.transform.position.y + 1, transform.position.z), transform.rotation);
            Anim.PlayJump();
        }
        if (collision.collider.CompareTag("Killer"))
        {
            Destroy(gameObject);
        }


    }
    
    public void FixedUpdate()
    {
        if(PlayerScript.MainCube!=null)
        Stickman.position = new Vector3(Stickman.position.x, PlayerScript.MainCube.transform.position.y+1.22f, Stickman.position.z);
    }
}
