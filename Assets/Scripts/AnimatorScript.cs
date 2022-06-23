using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorScript : MonoBehaviour
{
    public Animator _anim;

    public void PlayJump()
    {
        _anim.Play("Jumping");
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayJump();
        }
    }
}
