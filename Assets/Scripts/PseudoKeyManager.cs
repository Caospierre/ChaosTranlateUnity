using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PseudoKeyManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private List<PseudoKey> slots;
    [SerializeField] private Button closeButton;
    [Header("UI Panel Elements")]
    [SerializeField] private Button compilerButton;
    [SerializeField] private Button clearButton;
    [SerializeField] private GameObject codePanel;

    
    [Header("References")]
    [SerializeField] private TextEditorManager editor;

    void Start()
    {
        foreach (var slot in slots)
        {
            slot.UpdateState();
        }

        editor.ShowKeys();

        closeButton.onClick.RemoveAllListeners();
        closeButton.onClick.AddListener(ClosePanel);

        compilerButton.onClick.RemoveAllListeners();
        compilerButton.onClick.AddListener(OnCompile);

        clearButton.onClick.RemoveAllListeners();
        clearButton.onClick.AddListener(Clear);
    }

    public void AddKey(string value)
    {
        Debug.Log("new slot " + value);

        for (int i = 0; i < slots.Count; i++)
        {
            var slot = slots[i];
            string slotText = slot.GetText();

            Debug.Log("Slot index: " + i + " content: '" + slotText + "'");

            if (string.IsNullOrWhiteSpace(slotText))
            {
                Debug.Log("Asignando en slot #" + i);

                slot.Assign(value);
                editor.ShowKeys();

                return;
            }
        }

        Debug.Log("No available slots");
    }

    private void OnCompile()
    {
        string pseudoCode = editor.GetText();

        if (!string.IsNullOrWhiteSpace(pseudoCode))
        {
            TranslateClient.SendPseudoCode(
                pseudoCode,
                OnSuccess,
                OnError
            );
        }
    }

    private void OnSuccess(string result)
    {
        editor.SetVisorText(result);
    }

    void OnError(string error)
    {
        editor.Hidden();
        editor.SetErrorText(error);
    }

    private void ClosePanel()
    {
        gameObject.SetActive(false);
        Clear();
    }

    public void Clear()
    {
        editor.SetVisorText("");
        editor.SetTextEditor("");
        editor.ShowKeys();

    }

    public bool IsFocused() => editor.IsFocused();

    public void ShowKeys()
    {
        editor.ShowKeys();
    }

    public void ConfigureKeys(bool value)
    {
        editor.ConfigureKeys(value);
    }
}