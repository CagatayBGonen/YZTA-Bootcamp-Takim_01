using UnityEngine;
using UnityEngine.UI;

public class UIButtonSound : MonoBehaviour
{
    public AudioClip clickSound;
    private static AudioSource sharedAudioSource;

    private void Awake()
    {
        if (sharedAudioSource == null)
        {
            GameObject soundPlayer = GameObject.Find("UISoundPlayer");
            if (soundPlayer != null)
            {
                sharedAudioSource = soundPlayer.GetComponent<AudioSource>();
            }
            else
            {
                Debug.LogWarning("UIButtonSound: 'UISoundPlayer' adlý bir GameObject sahnede bulunamadý.");
            }
        }
    }

    public void PlayClickSound()
    {
        if (clickSound != null && sharedAudioSource != null)
        {
            sharedAudioSource.PlayOneShot(clickSound);
        }
        else
        {
            Debug.LogWarning("UIButtonSound: Ses çalýnamadý. AudioSource veya AudioClip eksik olabilir.");
        }
    }
}