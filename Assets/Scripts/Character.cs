using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    string currentAnim;
    public Animator animator;
    public CharacterRange range;
    public Bullet bulletPfb;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void AttackTarget()
    {
        if(range.charInRange.Count > 0)
        {
            Transform target = range.GetNearestTarget();
            if(target != null)
            {
                Bullet bullet = Instantiate(bulletPfb);
                bullet.transform.position = transform.position;
                Vector3 direction = (target.position - transform.position).normalized;
                bullet.GetComponent<Rigidbody>().AddForce(300f * direction); 
            }
        }    
    }    

    public void ChangeAnim(string animName)
    {
        if(currentAnim != animName)
        {
            if(animName == "idle")
            {
                AttackTarget();
            }    
            animator.ResetTrigger(currentAnim);
            currentAnim = animName;
            animator.SetTrigger(currentAnim);
        }
    }
}
