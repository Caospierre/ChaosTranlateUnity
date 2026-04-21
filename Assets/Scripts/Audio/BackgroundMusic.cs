using UnityEngine;
using UnityEngine.Audio;

public class BackgroundMusic : MonoBehaviour{

    [SerializeField] private AudioMixerSnapshot normalSnapshot;
    [SerializeField] private AudioMixerSnapshot pausedSnapshot;

    [SerializeField] private SoundArrayReferenceSO musicReference;
    private AudioSource audioSource;
    private int currentClipIndex;

    private void Start(){

        audioSource = GetComponent<AudioSource>();

    }

    private void Update(){

        if(!audioSource.isPlaying){

            PlayNextClip();

        }

    }

    public void PlayNextClip(){
        Debug.Log($"Referencia: {musicReference} | Array: {musicReference?.SoundArray} | Clips: {musicReference?.SoundArray?.AudioClips}");
        currentClipIndex = (currentClipIndex + 1) % musicReference.SoundArray.AudioClips.Length;
        audioSource.clip = musicReference.SoundArray.AudioClips[currentClipIndex];
        audioSource.Play();

    }

    public void SetPausedMode(){
        pausedSnapshot.TransitionTo(0.1f);
    }

    public void SetNormalMode(){
        normalSnapshot.TransitionTo(0.1f);
    }

}
