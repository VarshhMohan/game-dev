using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Reference to the VideoPlayer component
    public VideoClip[] videoClips;  // Array of video clips
    private bool startingStory = true; // Flag for initial story sequence
    private int currentClipIndex = 0;  // Current video index
    private bool isPlaying = false;   // Flag to check if a video is currently playing
    private bool triggeredVideoPlaying = false; // Flag for triggered videos

    void Start()
    {
        StartStory(); // Begin the story sequence
    }

    void Update()
    {
        if (startingStory && isPlaying)
        {
            // Handle initial story sequence (videos 0 to 4)
            if (Input.anyKeyDown && currentClipIndex < 4)
            {
                PlayNextVideo();
            }
            else if (Input.anyKeyDown && currentClipIndex == 4)
            {
                startingStory = false; // End the initial story sequence
                EndStory();
            }
        }
        else if (triggeredVideoPlaying && isPlaying)
        {
            // Handle triggered video playback
            if (Input.anyKeyDown)
            {
                StopTriggeredVideo();
            }
        }
    }

    public void StartStory()
    {
        currentClipIndex = 0;
        PlayVideo(currentClipIndex);
        isPlaying = true;
    }

    private void PlayVideo(int index)
    {
        if (index < videoClips.Length)
        {
            videoPlayer.clip = videoClips[index];
            videoPlayer.Play();
            isPlaying = true;
        }
    }

    public void PlayNextVideo()
    {
        currentClipIndex++;
        PlayVideo(currentClipIndex);
    }

    public void PlayVideoByTrigger(int index)
    {
        if (index >= 5 && index < videoClips.Length) // Only play videos 5 and above
        {
            triggeredVideoPlaying = true;
            PlayVideo(index);
        }
    }

    private void StopTriggeredVideo()
    {
        videoPlayer.Stop();
        triggeredVideoPlaying = false;
        isPlaying = false;
        Debug.Log("Triggered video stopped.");
        // Add logic to resume gameplay or other actions here
    }

    private void EndStory()
    {
        isPlaying = false;
        videoPlayer.Stop();
        Debug.Log("Initial story sequence ended.");
        // Add any additional logic here, such as enabling gameplay
    }
}
