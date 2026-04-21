using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PseudoKey : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TMP_Text label;
    [SerializeField] private Button button;

    [Header("References")]
    [SerializeField] private TextEditorManager editor;

    [SerializeField] private string value;

    void Awake()
    {
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(OnClick);
    }

    void Start()
    {
        UpdateState(); // Se ejecuta cuando todo ya está listo
    }

    void OnClick()
    {
        if (!string.IsNullOrWhiteSpace(label.text))
        {
            editor.AddWord(label.text);
        }
    }

    public void Assign(string newValue)
    {
        value = newValue;
        label.text = newValue;

        UpdateState();
    }

    public void Clear()
    {
        value = "";
        label.text = "";

        UpdateState();
    }

    public void UpdateState()
    {
        gameObject.SetActive(!string.IsNullOrWhiteSpace(label.text));
    }

    public string GetText()
    {
        return label.text;
    }
}