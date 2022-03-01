using System;

// Token: 0x0200448B RID: 17547
public class Skill2113 : BeSkill
{
	// Token: 0x0601864A RID: 99914 RVA: 0x0079A355 File Offset: 0x00798755
	public Skill2113(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x0601864B RID: 99915 RVA: 0x0079A35F File Offset: 0x0079875F
	public override void OnInit()
	{
		this.buffID = TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true);
	}

	// Token: 0x0601864C RID: 99916 RVA: 0x0079A384 File Offset: 0x00798784
	public override void OnStart()
	{
		this.RemoveHandle();
		this.handle = base.owner.RegisterEvent(BeEventType.onRemoveBuff, delegate(object[] args)
		{
			int num = (int)args[0];
			if (num == this.buffID)
			{
				base.PressAgainCancel();
			}
		});
	}

	// Token: 0x0601864D RID: 99917 RVA: 0x0079A3AB File Offset: 0x007987AB
	public override void OnCancel()
	{
		this.RemoveHandle();
		base.owner.buffController.RemoveBuff(this.buffID, 0, 0);
	}

	// Token: 0x0601864E RID: 99918 RVA: 0x0079A3CB File Offset: 0x007987CB
	public void RemoveHandle()
	{
		if (this.handle != null)
		{
			this.handle.Remove();
			this.handle = null;
		}
	}

	// Token: 0x040119A3 RID: 72099
	private int buffID;

	// Token: 0x040119A4 RID: 72100
	private BeEventHandle handle;
}
