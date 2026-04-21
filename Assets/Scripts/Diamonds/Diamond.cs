using UnityEngine;

public class Diamond : MonoBehaviour{

    [SerializeField] private string key;
    [SerializeField] private string secondKey;

    
    private void Start(){

        DiamondManager.Instance.RegisterDiamond(this);
        DiamondManager.Instance.CollectDiamond(this);

        
    }

    private void OnTriggerEnter2D(Collider2D other){

        if(other.TryGetComponent<Player>(out Player _)){
            DiamondManager.Instance.CollectDiamond(this);
            
            Destroy(gameObject);
        }

    }

    public string GetPseudoCode() => key;
    public string GetSecondPseudoCode() => secondKey;
}
