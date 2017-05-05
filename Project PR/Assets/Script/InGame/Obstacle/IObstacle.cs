using UnityEngine;
using System.Collections;

public enum Judge
{
    e_Perfact,
    e_Great,
    e_Good,
    e_Bad,
    e_Miss,
    e_None
}

public interface IObstacle {
    Judge JumpJudge(PlayerControl pc);
    Judge TriggerJudge(PlayerControl pc);
    void JumpEndJudge(PlayerControl pc);
    bool IsJudged
    {
        get;
    }
}
