using System;

// Token: 0x020044C1 RID: 17601
public class Skill3206 : BeSkill
{
	// Token: 0x060187CB RID: 100299 RVA: 0x007A4D4D File Offset: 0x007A314D
	public Skill3206(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x060187CC RID: 100300 RVA: 0x007A4D70 File Offset: 0x007A3170
	public override void OnInit()
	{
		this.delay = TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true);
		this.offsetX = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.skillData.ValueB[0], base.level, true), GlobalLogic.VALUE_1000);
		this.offsetZ = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.skillData.ValueB[1], base.level, true), GlobalLogic.VALUE_1000);
	}

	// Token: 0x060187CD RID: 100301 RVA: 0x007A4DFA File Offset: 0x007A31FA
	public override void OnStart()
	{
		this.handle1 = base.owner.RegisterEvent(BeEventType.onHitOther, delegate(object[] args)
		{
			this.RemoveHandles();
			base.owner.delayCaller.DelayCall(this.delay, delegate
			{
				this.CreateEntity();
				base.owner.AddShock(new ShockData(0.5f, 40f, 0.01f, 0f, 0));
			}, 0, 0, false);
		});
		this.handle2 = base.owner.RegisterEvent(BeEventType.onSkillCurFrame, delegate(object[] args)
		{
			string text = (string)args[0];
			if (text.Equals(this.frameFlag))
			{
				base.owner.AddShock(new ShockData(0.9f, 40f, 0.01f, 0f, 0));
			}
		});
	}

	// Token: 0x060187CE RID: 100302 RVA: 0x007A4E3C File Offset: 0x007A323C
	private void CreateEntity()
	{
		if (base.owner != null && !base.owner.IsDead())
		{
			VInt3 position = base.owner.GetPosition();
			position.x += ((!base.owner.GetFace()) ? 1 : -1) * this.offsetX.i;
			position.z += this.offsetZ.i;
			base.owner.AddEntity(this.entityId, position, 1, 0);
		}
	}

	// Token: 0x060187CF RID: 100303 RVA: 0x007A4ECF File Offset: 0x007A32CF
	public override void OnCancel()
	{
		this.RemoveHandles();
	}

	// Token: 0x060187D0 RID: 100304 RVA: 0x007A4ED7 File Offset: 0x007A32D7
	public override void OnFinish()
	{
		this.RemoveHandles();
	}

	// Token: 0x060187D1 RID: 100305 RVA: 0x007A4EDF File Offset: 0x007A32DF
	private void RemoveHandles()
	{
		if (this.handle1 != null)
		{
			this.handle1.Remove();
			this.handle1 = null;
		}
		if (this.handle2 != null)
		{
			this.handle2.Remove();
			this.handle2 = null;
		}
	}

	// Token: 0x04011AAC RID: 72364
	private int delay;

	// Token: 0x04011AAD RID: 72365
	private VInt offsetX;

	// Token: 0x04011AAE RID: 72366
	private VInt offsetZ;

	// Token: 0x04011AAF RID: 72367
	private BeEventHandle handle1;

	// Token: 0x04011AB0 RID: 72368
	private BeEventHandle handle2;

	// Token: 0x04011AB1 RID: 72369
	private int entityId = 60506;

	// Token: 0x04011AB2 RID: 72370
	private string frameFlag = "320601";
}
