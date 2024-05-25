using UnityEngine;


public class Rikayon : MonoBehaviour {

    public Animator animator;
    private bool _currentAttack = false;
    private bool _currentDead = false;
    private bool _currentDamaged = false;
    private bool _currentWalk = false;
	public void Attack1()
	{
        if (!_currentAttack)
        {
            animator.SetTrigger("Attack_1");
            _currentAttack = true;
        }
    }

    public void Dead()
    {
        if (!_currentDead)
        {
            animator.SetTrigger("Die");
            _currentDead = true;
        }
    }

    public void TakeDamage()
    {
        int randomeAnimationInt = Random.Range(0, 4);
        if (!_currentDamaged)
        {
            animator.SetTrigger("Take_Damage_"+randomeAnimationInt);
            _currentDamaged = true;
        }
    }

    public void Walk()
    {
        if (!_currentWalk)
        {
            animator.SetTrigger("Walk_Cycle_1");
            _currentWalk = true;
        }
    }

    public void CanAttack()
    {
        _currentAttack = false;
    }

    public void CanBeDamaged()
    {
        _currentDamaged = false;
    }

    public void CanWalk()
    {
        _currentWalk = false;
    }
}
