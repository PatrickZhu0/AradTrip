using System;
using UnityEngine;

// Token: 0x02000E69 RID: 3689
public class CPlayerInfo : MonoBehaviour
{
	// Token: 0x0600927D RID: 37501 RVA: 0x001B34D8 File Offset: 0x001B18D8
	public Color GetColor(PlayerInfoColor type)
	{
		switch (type)
		{
		case PlayerInfoColor.TOWN_PLAYER:
			return this.cTownPlayer;
		case PlayerInfoColor.TOWN_OTHER_PLAYER:
			return this.cTownOtherPlayer;
		case PlayerInfoColor.PK_PLAYER:
			return this.cPkPlayer;
		case PlayerInfoColor.PK_OTHER_PLAYER:
			return this.cPkOtherPlayer;
		case PlayerInfoColor.LEVEL_PLAYER:
			return this.cLevelPlayer;
		case PlayerInfoColor.TOWN_NPC:
			return this.cTownNPCs;
		case PlayerInfoColor.BOSS:
			return this.cBoss;
		case PlayerInfoColor.ELITE_MONSTER:
			return this.cEliteMonster;
		case PlayerInfoColor.SUMMON_MONSTER:
			return this.cSummonMonster;
		default:
			return Color.white;
		}
	}

	// Token: 0x0400499F RID: 18847
	public Color cTownPlayer = Color.white;

	// Token: 0x040049A0 RID: 18848
	public Color cTownOtherPlayer = Color.white;

	// Token: 0x040049A1 RID: 18849
	public Color cPkPlayer = Color.red;

	// Token: 0x040049A2 RID: 18850
	public Color cPkOtherPlayer = Color.blue;

	// Token: 0x040049A3 RID: 18851
	public Color cLevelPlayer = Color.white;

	// Token: 0x040049A4 RID: 18852
	public Color cTownNPCs = new Color(0.9686f, 0.8392f, 0.3529f, 1f);

	// Token: 0x040049A5 RID: 18853
	public Color cBoss = Color.magenta;

	// Token: 0x040049A6 RID: 18854
	public Color cEliteMonster = Color.green;

	// Token: 0x040049A7 RID: 18855
	public Color cSummonMonster = Color.blue;
}
