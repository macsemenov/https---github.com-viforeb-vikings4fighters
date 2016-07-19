using UnityEngine;
using System.Collections;

public class ssalat : MonoBehaviour
{
    public GUIStyle ImageBackground;
    public GUIStyle ImageButtonRegistration;
    public GUIStyle ImageButtonLogin;
    public AudioClip SoundBackground;
    public AudioClip SoundButtonClick;
    public AudioClip SoundButtonOver;
    public string lastTooltip = " ";

    void Start()
    {
        AudioSource.PlayClipAtPoint(SoundBackground, transform.position);
    }

    void OnGUI()
    {

        GUI.Box(new Rect((Screen.width - 246) / 2, (Screen.height - 128) / 2, 246, 128), "", ImageBackground);
        if (GUI.Button(new Rect((Screen.width - 180) / 2, (Screen.height - -150) / 2, 81, 28), new GUIContent("", "SoundButtonOver"), ImageButtonRegistration))
        {
            AudioSource.PlayClipAtPoint(SoundButtonClick, transform.position);
        }
        if (GUI.Button(new Rect((Screen.width - -15) / 2, (Screen.height - -150) / 2, 81, 28), "", ImageButtonLogin))
        {
            AudioSource.PlayClipAtPoint(SoundButtonClick, transform.position);
        }
        if (Event.current.type == EventType.Repaint && GUI.tooltip != lastTooltip)
        {

            if (GUI.tooltip != "")
                SendMessage(GUI.tooltip + "OnMouseOver", SendMessageOptions.DontRequireReceiver);

            lastTooltip = GUI.tooltip;
        }
    }

    void SoundButtonOverOnMouseOver()
    {
        AudioSource.PlayClipAtPoint(SoundButtonOver, transform.position);
    }
}