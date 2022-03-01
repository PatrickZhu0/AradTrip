using System;

// Token: 0x020041B2 RID: 16818
public class MonsterIDData
{
	// Token: 0x060171BE RID: 94654 RVA: 0x00716E20 File Offset: 0x00715220
	public MonsterIDData(int oldId)
	{
		if (oldId.ToString().Length < 7)
		{
			this.mid = oldId;
			this.level = 1;
			this.type = 1;
			this.difficulty = 1;
		}
		else
		{
			int num = oldId;
			this.level = num % GlobalLogic.VALUE_10000 / GlobalLogic.VALUE_100;
			this.type = num % GlobalLogic.VALUE_100 / GlobalLogic.VALUE_10;
			this.difficulty = num % GlobalLogic.VALUE_10;
			this.mid = oldId - this.level * GlobalLogic.VALUE_100;
			this.level = Math.Max(1, this.level);
		}
	}

	// Token: 0x060171BF RID: 94655 RVA: 0x00716EC8 File Offset: 0x007152C8
	public int GenMonsterID(int level)
	{
		this.level = level;
		return this.mid += level * GlobalLogic.VALUE_100;
	}

	// Token: 0x060171C0 RID: 94656 RVA: 0x00716EF3 File Offset: 0x007152F3
	public void SetID(int id)
	{
		this._decodeID(id);
	}

	// Token: 0x060171C1 RID: 94657 RVA: 0x00716EFC File Offset: 0x007152FC
	private void _decodeID(int id)
	{
		this.difficulty = id % GlobalLogic.VALUE_10;
		int num = id / GlobalLogic.VALUE_10;
		this.type = num % GlobalLogic.VALUE_10;
		num /= GlobalLogic.VALUE_10;
		this.level = num % GlobalLogic.VALUE_100;
		num /= GlobalLogic.VALUE_100;
		this.mid = num;
	}

	// Token: 0x060171C2 RID: 94658 RVA: 0x00716F54 File Offset: 0x00715354
	public int GenFullMonsterID(int level)
	{
		int num = this.mid;
		num *= GlobalLogic.VALUE_100;
		num += level % GlobalLogic.VALUE_100;
		num *= GlobalLogic.VALUE_10;
		num += this.type % GlobalLogic.VALUE_10;
		num *= GlobalLogic.VALUE_10;
		num += this.difficulty % GlobalLogic.VALUE_10;
		this.level = level;
		return num;
	}

	// Token: 0x04010A71 RID: 68209
	public int mid;

	// Token: 0x04010A72 RID: 68210
	public int level;

	// Token: 0x04010A73 RID: 68211
	public int type;

	// Token: 0x04010A74 RID: 68212
	public int difficulty;
}
