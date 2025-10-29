using System.Collections;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    // 애니메이션 설정 담당

    Animator anim;
    PlayerController playerController;

    private Coroutine footstepCoroutine;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {        
        if (playerController.IsMoving && playerController.IsGroundedCheck)
        {
            if (!anim.GetBool("Walking"))
            {
                anim.SetBool("Walking", true);
                if (footstepCoroutine == null)
                    footstepCoroutine = StartCoroutine(PlayFootsteps());
            }
        }
        else if (anim.GetBool("Walking"))
        {
            anim.SetBool("Walking", false);
            if (footstepCoroutine != null)
            {
                StopCoroutine(footstepCoroutine);
                footstepCoroutine = null;
            }
        }
    }

    public void SetArmed(bool armed)
    {
        anim.SetBool("Arm", armed);
    }

    public void SetFire()
    {
        anim.SetTrigger("Fire");
    }

    public void SetReload()
    {
        anim.SetTrigger("Reload");
    }

    private IEnumerator PlayFootsteps()
    {
        while (true)
        {
            SoundManagers.Instance.PlayFootstep();
            yield return new WaitForSeconds(0.4f);
        }
    }
}
