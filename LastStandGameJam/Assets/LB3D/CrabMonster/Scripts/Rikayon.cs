using UnityEngine;


public class Rikayon : MonoBehaviour {

    public Animator animator;
    private bool currentAttack = false;
    private bool currentDead = false;
    private bool currentDamaged = false;
	public void Attack1()
	{
        if (!currentAttack)
        {
            animator.SetTrigger("Attack_1");
            currentAttack = true;
        }
    }

    public void Dead()
    {
        if (!currentDead)
        {
            animator.SetTrigger("Die");
            currentDead = true;
        }
    }

    public void TakeDamage()
    {
        int randomeAnimationInt = Random.Range(0, 4);
        if (!currentDamaged)
        {
            animator.SetTrigger("Take_Damage_"+randomeAnimationInt);
            currentDamaged = true;
        }
    }

    public void CanAttack()
    {
        currentAttack = false;
    }

    public void CanBeDamaged()
    {
        currentDamaged = false;
    }
}
