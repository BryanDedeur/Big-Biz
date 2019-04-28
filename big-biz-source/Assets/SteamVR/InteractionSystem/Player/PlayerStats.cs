using System;
using System.Collections.Generic;

public class PlayerStats
{
	public float BaseValue;

	// Less calculations, only calculate if changes made
	public float Value
	{
		get
		{
			if (isDirty)
			{
				_value = CalculateFinalValue();
				isDirty = false;
			}
			return _value;
		}
	}

	private bool isDirty = true;
	private float _value;

	private readonly List<PlayerStatsModifier> statModifiers;

	public PlayerStats(float baseValue)
	{
		BaseValue = baseValue;
		statModifiers = new List<PlayerStatsModifier>();
	}

	public void AddModifier(PlayerStatsModifier mod)
	{
		isDirty = true;
		statModifiers.Add(mod);
		// Multiplicative bonuses should come first
		statModifiers.Sort(CompareModifierOrder);
	}

	// Helper function for statModifier sort to sort by order
	private int CompareModifierOrder(PlayerStatsModifier a, PlayerStatsModifier b)
	{
		if (a.Order < b.Order)
		{
			return -1;
		}
		else if(a.Order > b.Order)
		{
			return 1;
		}
		return 0; // a == b
	}

	public bool RemoveModifier(PlayerStatsModifier mod)
	{
		isDirty = true;
		return statModifiers.Remove(mod);
	}

	private float CalculateFinalValue()
	{
		float finalValue = BaseValue;
		float sumPercentAdd = 0;

		for(int i = 0; i < statModifiers.Count; i++)
		{
			PlayerStatsModifier mod = statModifiers[i];
			if(mod.Type == StatModType.Flat)
			{
				finalValue += mod.Value;
			}
			// If we decide to add multiplicative bonuses, e.g. high end furniture upgrade
			// could make the restaurant earn 10% more or something.
			else if(mod.Type == StatModType.Percent)
			{
				// Use this code if multiplicative bonuses should not stack multiplicatively, e.g.
				// two 100% bonuses become +200% instead of +400%
				sumPercentAdd += mod.Value;
				if(i + 1 >= statModifiers.Count || statModifiers[i + 1].Type != StatModType.Percent)
				{
					finalValue *= 1 + sumPercentAdd;
					sumPercentAdd = 0;
				}
				// Use this code if multiplicative bonuses SHOULD stack multiplicatively instead
				// finalValue *= 1 + mod.Value;
			}

		}

		// If we end up dealing with cents
		// return (float)Math.Round(finalValue, 2);
		return finalValue;
	}
}
