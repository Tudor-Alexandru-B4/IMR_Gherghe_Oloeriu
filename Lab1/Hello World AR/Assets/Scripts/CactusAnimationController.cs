using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusAnimationController : MonoBehaviour
{

    Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AnimationIdle()
    {
        Debug.Log("AnimationIdle");
        animator.ResetTrigger("BeginAttack");
        animator.SetTrigger("BeginIdle");
    }

    public void AnimationAttack()
    {
        Debug.Log("AnimationAttacks");
        animator.ResetTrigger("BeginIdle");
        animator.SetTrigger("BeginAttack");
    }

}
