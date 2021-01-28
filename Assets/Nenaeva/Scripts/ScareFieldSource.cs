using UnityEngine;

public class ScareFieldSource : MonoBehaviour
{
    private ScareField[] fields;

    private void Awake()
    {
        fields = GetComponentsInChildren<ScareField>();
    }
    public void SetFieldState(ScareFieldState state)
    {
        foreach (var f in fields)
        {
            f.SetFieldState(state);
        }
    }

}