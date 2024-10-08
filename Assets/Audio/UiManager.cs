using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Slider _musicSlider; // Tham chiếu đến slider âm lượng
    public GameObject panel;     // Tham chiếu đến panel

    private void Start()
    {
        // Thiết lập giá trị của slider theo âm lượng hiện tại
        _musicSlider.value = AudioManager.Instance.musicSource.volume;
        // Gắn hàm điều chỉnh âm lượng vào sự kiện thay đổi của slider
        _musicSlider.onValueChanged.AddListener(delegate { MusicVolume(); });
    }

    public void ToggleMusic()
    {
        AudioManager.Instance.ToggleMusic();
    }

    public void MusicVolume()
    {
        // Cập nhật âm lượng nhạc theo giá trị của slider
        AudioManager.Instance.MusicVolume(_musicSlider.value);
    }

    public void TogglePanel()
    {
        // Bật hoặc tắt panel
        panel.SetActive(!panel.activeSelf);
    }
}
