using UnityEngine;

public class AnimationSoundBridge : MonoBehaviour
{
    // 총 발사 소리
    public void PlayFireEvent()
    {
        SoundManagers.Instance?.PlayFire();
    }

    // 발자국 소리 (걷기/달리기 애니메이션 이벤트에서 호출)
    public void PlayFootstepEvent()
    {
        SoundManagers.Instance?.PlayFootstep();
    }

    // 리로드 소리 (리로드 애니메이션 이벤트에서 호출)
    public void PlayReloadEvent()
    {
        // 리로드 소리가 따로 필요하다면 SoundManagers에 Reload 추가
        // ex) SoundManagers.Instance?.PlayReload();
        Debug.Log("Reload Sound Event Triggered");
    }
}
