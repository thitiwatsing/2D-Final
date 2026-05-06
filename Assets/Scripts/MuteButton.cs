using UnityEngine;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour
{
    [Header("Audio")]
    public AudioSource bgmAudioSource;

    [Header("Sprites")]
    public Sprite soundOnSprite;
    public Sprite soundOffSprite;

    private Button button;
    private Image buttonImage;
    private bool isMuted = false;

    void Start()
    {
        button = GetComponent<Button>();
        buttonImage = GetComponent<Image>();

        button.onClick.AddListener(ToggleMute);

        // แสดง Sprite เริ่มต้น
        buttonImage.sprite = soundOnSprite;
    }

    void ToggleMute()
    {
        isMuted = !isMuted;
        bgmAudioSource.mute = isMuted;

        // สลับ Sprite
        buttonImage.sprite = isMuted ? soundOffSprite : soundOnSprite;
    }
}