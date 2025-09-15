using UnityEngine;

public class ApplyStickyGA : GameAction
{
    public int stickyStacks { get; private set; }
    public CombatantView target { get; private set; }
    
    public ApplyStickyGA(int stickyStacks, CombatantView target)
    {
        this.stickyStacks = stickyStacks;
        this.target = target;
    }
}
