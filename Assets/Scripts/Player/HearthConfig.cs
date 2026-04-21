using UnityEngine;

public class HearthConfig : MonoBehaviour
{
    [SerializeField] private HearthState state;

    public void NextState()
    {
        state = state.Next();
        Debug.Log(state);
    }
    
    public HearthState getState()=> state;
}
