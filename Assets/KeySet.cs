using UnityEngine;
using System.Collections;

public class KeySet : MonoBehaviour {

    KeyCode rightMove;
    KeyCode leftMove;
    KeyCode split;
    KeyCode jump;

    public KeySet(KeyCode rm, KeyCode lm, KeyCode s, KeyCode j)
    {
        rightMove = rm;
        leftMove = lm;
        split = s;
        jump = j;
    }

	public KeyCode returnLeftKey()
    {
        return leftMove;
    }
    public KeyCode returnRightKey()
    {
        return rightMove;
    }
    public KeyCode returnJumpKey()
    {
        return jump;
    }
    public KeyCode returnSplitKey()
    {
        return split;
    }
}
