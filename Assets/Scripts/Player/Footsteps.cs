using UnityEngine;

public class Footsteps : MonoBehaviour
{
    [Header("Audio Settings")]
    [SerializeField] private AudioSource footstepsSource;
    [SerializeField] private AudioClip footstepNatureClip;
    [SerializeField] private AudioClip footstepWoodClip;

    private bool isBridge;

    public void PlayFootstepSound()
    {
        if (footstepsSource == null || footstepNatureClip == null || footstepWoodClip == null) return;

       
        footstepsSource.pitch = Random.Range(0.9f, 1.1f);

        if (isBridge)
        {
            footstepsSource.PlayOneShot(footstepWoodClip);
        }
        else
        {
            footstepsSource.PlayOneShot(footstepNatureClip);
        }
    }

    public void SetBridgeState(bool state)
    {
        isBridge = state;
        Debug.Log("Stato ponte aggiornato a: " + isBridge);
    }
}