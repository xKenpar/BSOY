using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkObject : MonoBehaviour
{
    [SerializeField, TextArea] List<string> Texts;
    // Start is called before the first frame update
    void Update() {
        if(Input.anyKeyDown)
            TextBoxManager.Instance.AdvanceText();
    }
    void OnEnable() {
        TextBoxManager.Instance.SetText(Texts,"bruh");
    }

}
