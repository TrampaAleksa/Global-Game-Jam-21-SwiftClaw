using UnityEngine;

public class ScareFieldSource : MonoBehaviour
{
    private ScareField[] fields;
    public Animator snakeAnimator;

    private void Awake()
    {
        fields = GetComponentsInChildren<ScareField>();
        snakeAnimator = GetComponentInChildren<Animator>();
    }
    public void SetFieldState(ScareFieldState state)
    {
        foreach (var f in fields)
        {
            f.SetFieldState(state);
        }
    }

}