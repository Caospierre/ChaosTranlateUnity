using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Collections;
public class PythonVisor : MonoBehaviour
{
    [SerializeField] private TMP_Text codeText;
    [SerializeField] private GameObject pseudoCodeKeys;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetText(String code)
    {
        Show();
        codeText.text = code;
    }

    public void SetErrorText(string error)
    {
        StopAllCoroutines(); 

        codeText.text = "<color=red>" + error + "</color>";
        Show(); // muestras el error

        StartCoroutine(ShowKeysAfterDelay(2f));
    }

    IEnumerator ShowKeysAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        Hidden();   
    }

    public void Hidden()
    {
        gameObject.SetActive(false);   
        ShowKeys();
    }

    public void Show()
    {
        HideKeys();
        gameObject.SetActive(true);
    }

    public void HideKeys()
    {
        pseudoCodeKeys.SetActive(false);

    }

    public void ShowKeys()
    {
        pseudoCodeKeys.SetActive(true);
    }
    public void ConfigureKeys(bool value)
    {
        pseudoCodeKeys.SetActive(value);
    }
    

    
}
