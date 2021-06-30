using UnityEngine;
using UnityEngine.UI;

public enum State
{
    Open,
    Close,
}

public class Cell : MonoBehaviour
{
    private State state = State.Close;

    public State m_state
    {
        get => state;

        set
        {
            state = value;
        }
    }

}
