using UnityEngine;
using TMPro;

public class TextEditorManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private PythonVisor visor;

    public void AddWord(string word)
    {
        int position = inputField.caretPosition;

        inputField.text = inputField.text.Insert(position, word + "\n");
        inputField.caretPosition = position + word.Length + 1;

        inputField.ActivateInputField();
    }

    public void SetTextEditor(string text)
    {
        inputField.text = text;
    }

    public string GetText()
    {
        return inputField.text.Trim();
    }

    public void SetVisorText(string text)
    {
        visor.SetText(text);
    }

    public void SetErrorText(string error)
    {
        visor.SetErrorText(error);
    }

    public void Hidden()
    {
        visor.Hidden();
        
    }

    public void ShowKeys()
    {
        visor.ShowKeys();
    }
    
    public void ConfigureKeys(bool value)
    {
        visor.ConfigureKeys(value);
    }



    
    public bool IsFocused()=>inputField.isFocused;
    
}