using UnityEngine;


public class Rikayon : MonoBehaviour {

    public Animator animator;
    private bool _currentAttack = false;
    [SerializeField] private bool _currentDead = false;
    private bool _currentDamaged = false;
    private bool _currentWalk = false;
	public void Attack1()
	{
        if (!_currentAttack && !_currentDead)
        {
            animator.SetTrigger("Attack_1");
            _currentAttack = true;
        }
    }

    public void Dead()
    {
        if (!_currentDead)
        {
            ResetAnimBool();
            animator.SetTrigger("Die");
        }
    }

    public void TakeDamage()
    {
        int randomAnimationInt = Random.Range(0, 4);
        if (!_currentDamaged && !_currentDead)
        {
            animator.SetTrigger("Take_Damage_"+randomAnimationInt);
            _currentDamaged = true;
        }
    }

    public void Walk()
    {
        if (!_currentWalk && !_currentDead)
        {
            animator.SetTrigger("Walk_Cycle_1");
            _currentWalk = true;
        }
    }

    public void CheckDeadAnim()
    {
        _currentDead = true;
    }

    public bool IsDead()
    {
        return _currentDead;
    }

    public void CanAttack()
    {
        _currentAttack = false;
        animator.ResetTrigger("Attack_1");
    }

    public void CanBeDamaged()
    {
        _currentDamaged = false;
        animator.ResetTrigger("Take_Damage_1");
        animator.ResetTrigger("Take_Damage_2");
        animator.ResetTrigger("Take_Damage_3");
    }

    public void CanWalk()
    {
        _currentWalk = false;
        animator.ResetTrigger("Walk_Cycle_1");
    }

    public void ResetAnimBool()
    {
        CanAttack();
        CanBeDamaged();
        CanWalk();
    }
}
