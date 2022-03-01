using System;

// Token: 0x02004251 RID: 16977
public class Mechanism1010 : BeMechanism
{
	// Token: 0x060177D1 RID: 96209 RVA: 0x00739394 File Offset: 0x00737794
	public Mechanism1010(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060177D2 RID: 96210 RVA: 0x0073939E File Offset: 0x0073779E
	public override void OnInit()
	{
		this.hurtId = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
	}

	// Token: 0x060177D3 RID: 96211 RVA: 0x007393C8 File Offset: 0x007377C8
	public override void OnStart()
	{
		this.yPos = base.owner.GetPosition().y;
		this.handleB = base.owner.RegisterEvent(BeEventType.onHitOther, delegate(object[] args)
		{
			BeActor beActor = (BeActor)args[0];
			int num = (int)args[1];
			if (beActor == null || num != this.hurtId)
			{
				return;
			}
			if (beActor.stateController == null)
			{
				return;
			}
			if (!beActor.stateController.CanMove())
			{
				return;
			}
			if (beActor.stateController.CanNotAbsorbByBlockHole())
			{
				return;
			}
			VInt3 position = beActor.GetPosition();
			beActor.SetPosition(new VInt3(position.x, this.yPos, position.z), false, true, false);
		});
	}

	// Token: 0x04010E0E RID: 69134
	private int hurtId;

	// Token: 0x04010E0F RID: 69135
	private int yPos;
}
