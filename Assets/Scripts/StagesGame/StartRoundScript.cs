using System;

public class StartRoundScript
{
    public event Action RoundStarted;

    public void StartedRound()
    {
        RoundStarted();
    }
}
