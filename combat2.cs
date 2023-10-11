using UnityEngine;

public struct combat {
	public int health;
	public int health_regen;
	public stats _stats;
	public weapon _weapon;
	public armor _armor;


	public int attack_physical(combat enemy, bool ranged) {
		float chance;
		int damage;

		chance = (_stats.get(stat.agility) + _weapon.accuracy) / (enemy._stats.get(stat.agility) + enemy._armor.dodge);

		if (chance < Random.Range(0.00f, 1.00f)) { return 0; }

		damage =  ranged ? _weapon.damage_ranged : _weapon.damage_melee;
		damage += _stats.get(_weapon.stat_primary);
		damage -= enemy._armor.defense;

		return damage >= 0 ? damage : 0;
	}
}

public enum stat { strength, agility, intelligence }

public struct stats {
	public int strength;
	public int agility;
	public int intelligence;

	public int get(stat _stat) {
		if (_stat == stat.strength) { return strength; }
		if (_stat == stat.agility) { return agility; }
		return intelligence;
	}
}


public struct weapon {
	public stat stat_primary;
	public int damage_ranged;
	public int damage_melee;
	public int accuracy;

	public int bonus;
}

public struct armor {
	public int dodge;
	public int defense;
}