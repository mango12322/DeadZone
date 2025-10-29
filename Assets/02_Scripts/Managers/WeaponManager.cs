using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    // 무기 담당 (Input)

    PlayerAnimator playerAnimator;
    
    void Start()
    {
        playerAnimator = GetComponent<PlayerAnimator>();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            playerAnimator.SetArmed(!IsArmed());
        }

        if (Input.GetMouseButtonDown(0))
        {
            playerAnimator.SetFire();
            // SoundManagers.Instance.PlayFire();
        }

        if (Input.GetKeyDown(KeyCode.R))
            playerAnimator.SetReload();
    }

    bool IsArmed()
    {
        return GetComponentInChildren<Animator>().GetBool("Arm");
    }

}