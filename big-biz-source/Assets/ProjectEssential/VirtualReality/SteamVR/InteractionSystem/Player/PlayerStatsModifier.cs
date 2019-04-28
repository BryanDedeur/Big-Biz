public enum StatModType
{
	Percent,
	Flat,
}

public class PlayerStatsModifier
{
	public readonly float Value;
	public readonly StatModType Type;
	public readonly int Order;

	public PlayerStatsModifier(float value, StatModType type, int order)
	{
		Value = value;
		Type = type;
		Order = order;
	}

	// This makes percentage modifiers apply to BASE stat before applying additive multipliers
	// Since Percent is in index 0 in the enum
	public PlayerStatsModifier(float value, StatModType type) : this (value, type, (int)type) { }
}
