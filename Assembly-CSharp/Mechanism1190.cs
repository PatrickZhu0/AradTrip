using System;
using GameClient;

// Token: 0x020042F4 RID: 17140
public class Mechanism1190 : BeMechanism
{
	// Token: 0x06017B7B RID: 97147 RVA: 0x0074F935 File Offset: 0x0074DD35
	public Mechanism1190(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017B7C RID: 97148 RVA: 0x0074F93F File Offset: 0x0074DD3F
	public override void OnInit()
	{
		this.rate = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
	}

	// Token: 0x06017B7D RID: 97149 RVA: 0x0074F96C File Offset: 0x0074DD6C
	public override void OnStart()
	{
		if (base.owner == null || base.owner.CurrentBeScene == null)
		{
			return;
		}
		this.SceneHandleNewA = base.owner.CurrentBeScene.RegisterEventNew(BeEventSceneType.onElectricBuffHurt, new BeEvent.BeEventHandleNew.Function(this._onElectricBuffHurt));
	}

	// Token: 0x06017B7E RID: 97150 RVA: 0x0074F9BC File Offset: 0x0074DDBC
	private void _onElectricBuffHurt(BeEvent.BeEventParam param)
	{
		if (param == null)
		{
			return;
		}
		BeActor beActor = param.m_Obj as BeActor;
		BeActor beActor2 = param.m_Obj2 as BeActor;
		if (beActor == null || beActor2 == null)
		{
			return;
		}
		if (beActor.GetCamp() == base.owner.GetCamp() && beActor2.GetPID() == base.owner.GetPID())
		{
			param.m_Int += this.rate;
		}
	}

	// Token: 0x040110AA RID: 69802
	private int rate;
}
