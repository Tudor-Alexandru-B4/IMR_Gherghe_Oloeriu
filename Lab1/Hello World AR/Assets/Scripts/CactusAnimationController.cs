using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusAnimationController : MonoBehaviour
{

    Animator animator;
    new GameObject camera;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        camera = GameObject.Find("AR Camera");
    }

    // Update is called once per frame
    void Update()
    {
        var lookPos = camera.transform.position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 30f);
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
