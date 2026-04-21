using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DiamondManager : Singleton<DiamondManager>{

    [SerializeField] private TMP_Text diamondText;
    [SerializeField] private PseudoKeyManager manager;

    private int totalDiamonds;
    private int collectedDiamonds;

    public void RegisterDiamond(Diamond diamond){

        totalDiamonds++;
        UpdateUI();

    }

    public void CollectDiamond(Diamond diamond){
        manager.AddKey(diamond.GetPseudoCode());
        manager.AddKey(diamond.GetSecondPseudoCode());

        collectedDiamonds++;
        UpdateUI();

    }

    private void UpdateUI(){

        diamondText.text = $"{collectedDiamonds} / {totalDiamonds}";

    }

}
