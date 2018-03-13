using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoControl : MonoBehaviour
{
    public GameObject videoUI;
   
    
    public GameObject end;


    private UnityEngine.Video.VideoPlayer videoPlayer;

    


    [SerializeField]
    private AudioSource audioSource;



    void Start()
    {
        end.SetActive(false);
        videoUI.SetActive(true);
        videoPlayer = GetComponent<UnityEngine.Video.VideoPlayer>();


        if (videoPlayer.clip != null)
        {
            videoPlayer.EnableAudioTrack(0, true);
            videoPlayer.SetTargetAudioSource(0, audioSource);
        }
        RestartVideo();

     
        videoPlayer.loopPointReached += End;
    }

    //Check if input keys have been pressed and call methods accordingly.
    void Update()
    {
        

    }

    public void PauseVideo()
    {
        Debug.Log("Pause");
        if (videoPlayer.isPlaying)
            videoPlayer.Pause();
        else
            videoPlayer.Play();
        audioSource.Play();
    }

    public void RestartVideo()
    {
        Debug.Log("Restart");
        videoPlayer.Stop();
        videoPlayer.Play();
        audioSource.Play();
    }

    public void End(UnityEngine.Video.VideoPlayer vp)
    {
        end.SetActive(true);
        videoUI.SetActive(false);
    }
}