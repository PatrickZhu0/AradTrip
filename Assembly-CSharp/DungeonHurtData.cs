using System;

// Token: 0x020041E4 RID: 16868
public class DungeonHurtData
{
	// Token: 0x06017532 RID: 95538 RVA: 0x0072D570 File Offset: 0x0072B970
	public DungeonHurtData()
	{
		this.skillId = 0;
		this.hurtId = 0;
		this.damage = 0;
	}

	// Token: 0x06017533 RID: 95539 RVA: 0x0072D58D File Offset: 0x0072B98D
	public DungeonHurtData(int skillId, int hurtId, int damage)
	{
		this.skillId = skillId;
		this.hurtId = hurtId;
		this.damage = damage;
	}

	// Token: 0x17001FBE RID: 8126
	// (get) Token: 0x06017534 RID: 95540 RVA: 0x0072D5AA File Offset: 0x0072B9AA
	// (set) Token: 0x06017535 RID: 95541 RVA: 0x0072D5B2 File Offset: 0x0072B9B2
	public int skillId { get; set; }

	// Token: 0x17001FBF RID: 8127
	// (get) Token: 0x06017536 RID: 95542 RVA: 0x0072D5BB File Offset: 0x0072B9BB
	// (set) Token: 0x06017537 RID: 95543 RVA: 0x0072D5C3 File Offset: 0x0072B9C3
	public int hurtId { get; set; }

	// Token: 0x17001FC0 RID: 8128
	// (get) Token: 0x06017538 RID: 95544 RVA: 0x0072D5CC File Offset: 0x0072B9CC
	// (set) Token: 0x06017539 RID: 95545 RVA: 0x0072D5D4 File Offset: 0x0072B9D4
	public int damage { get; set; }
}
