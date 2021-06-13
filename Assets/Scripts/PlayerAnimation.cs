using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public string inAir;
    public string Moving;
    public string Jumping;
    public string Hurt;
    public SkinnedMeshRenderer Suit;
    public Animator SuitAnimator;
    public SkinnedMeshRenderer NoSuit;
    public Animator NoSuitAnimator;
    public bool Suited;

    public void SetAir(bool air)
    {
        SuitAnimator.SetBool(inAir, air);
        NoSuitAnimator.SetBool(inAir, air);
    }
    public void SetMoving(bool moving)
    {
        SuitAnimator.SetBool(Moving, moving);
        NoSuitAnimator.SetBool(Moving, moving);
    }
    public void SetJumping()
    {
        SuitAnimator.SetTrigger(Jumping);
        NoSuitAnimator.SetTrigger(Jumping);
    }
    public void SetHurting()
    {
        SuitAnimator.SetTrigger(Hurt);
        NoSuitAnimator.SetTrigger(Hurt);
    }

    // Update is called once per frame
    void Update()
    {
        if (Suited)
        {
            Suit.enabled = true ;
            NoSuit.enabled = false;
        }
        else
        {
            Suit.enabled = false;
            NoSuit.enabled = true;
        }
    }
}
