using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class ControllerVibration : MonoBehaviour {

    bool playerIndexSet = false;
    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;

    // Start is called before the first frame update
    void Start()
    {
        GamePad.SetVibration(playerIndex, state.Triggers.Left, state.Triggers.Right);
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerIndexSet || !prevState.IsConnected)
        {
            for (int i = 0; i < 4; ++i)
            {
                PlayerIndex testPlayerIndex = (PlayerIndex)i;
                GamePadState testState = GamePad.GetState(testPlayerIndex);
                if (testState.IsConnected)
                {
                    Debug.Log(string.Format("GamePad found {0}", testPlayerIndex));
                    playerIndex = testPlayerIndex;
                    playerIndexSet = true;
                }
            }
        }

        prevState = state;
        state = GamePad.GetState(playerIndex);
    }
}
