using UnityEngine;
using UnityEngine.UIElements;

public class SoundManagers : MonoBehaviour
{
    public static SoundManagers Instance { get; private set; }

    [SerializeField] AudioSource[] footSteps;
    [SerializeField] AudioSource fire;
    [SerializeField] AudioSource reload;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    public void PlayFootstep()
    {
        if (footSteps.Length == 0) return;

        AudioSource audioSource = new AudioSource();
        int n = Random.Range(0, footSteps.Length);

        audioSource = footSteps[n];
        audioSource.Play();
        footSteps[n] = footSteps[0];
        footSteps[0] = audioSource;
    }

    public void PlayFire() => fire?.Play();
    public void PlayReload() => reload?.Play();

   
}
