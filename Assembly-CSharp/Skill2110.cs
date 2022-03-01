using System;

// Token: 0x02004488 RID: 17544
public class Skill2110 : BeSkill
{
	// Token: 0x06018632 RID: 99890 RVA: 0x007996EE File Offset: 0x00797AEE
	public Skill2110(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06018633 RID: 99891 RVA: 0x007996F8 File Offset: 0x00797AF8
	public override void OnInit()
	{
		this.buffID = TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true);
	}

	// Token: 0x06018634 RID: 99892 RVA: 0x0079971D File Offset: 0x00797B1D
	private void RemoveHandle()
	{
		if (this.handle != null)
		{
			this.handle.Remove();
			this.handle = null;
		}
	}

	// Token: 0x06018635 RID: 99893 RVA: 0x0079973C File Offset: 0x00797B3C
	public override void OnPostInit()
	{
		this.RemoveHandle();
		this.handle = base.owner.RegisterEvent(BeEventType.onSummon, delegate(object[] args)
		{
			BeActor beActor = args[0] as BeActor;
			if (beActor != null && beActor.m_iCamp == base.owner.m_iCamp && beActor.GetEntityData().isSummonMonster)
			{
				beActor.buffController.TryAddBuff(this.buffID, -1, base.level);
			}
		});
	}

	// Token: 0x04011998 RID: 72088
	private int buffID;

	// Token: 0x04011999 RID: 72089
	private BeEventHandle handle;
}
