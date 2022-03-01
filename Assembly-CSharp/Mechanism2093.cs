using System;
using GameClient;

// Token: 0x02004399 RID: 17305
public class Mechanism2093 : BeMechanism
{
	// Token: 0x06017FE9 RID: 98281 RVA: 0x0076FB33 File Offset: 0x0076DF33
	public Mechanism2093(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017FEA RID: 98282 RVA: 0x0076FB3D File Offset: 0x0076DF3D
	public override void OnInit()
	{
	}

	// Token: 0x06017FEB RID: 98283 RVA: 0x0076FB40 File Offset: 0x0076DF40
	public override void OnStart()
	{
		if (base.owner == null)
		{
			return;
		}
		this.ChangeChaseSize();
		if (!BattleMain.IsModePvP(base.battleType))
		{
			this.handleNewA = base.owner.RegisterEventNew(BeEventType.onAddChaser, new BeEvent.BeEventHandleNew.Function(this.ChangeCreateChaseSize));
		}
	}

	// Token: 0x06017FEC RID: 98284 RVA: 0x0076FB94 File Offset: 0x0076DF94
	private void ChangeChaseSize()
	{
		if (base.owner == null)
		{
			return;
		}
		BeMechanism mechanism = base.owner.GetMechanism(Mechanism2072.ChaserMgrID);
		if (mechanism == null)
		{
			Logger.LogErrorFormat("未找到机制2072", new object[0]);
			return;
		}
		Mechanism2072 mechanism2 = mechanism as Mechanism2072;
		if (mechanism2 != null)
		{
			mechanism2.SetChaseSize(Mechanism2072.ChaseSizeType.Big);
		}
	}

	// Token: 0x06017FED RID: 98285 RVA: 0x0076FBEC File Offset: 0x0076DFEC
	private void ChangeCreateChaseSize(BeEvent.BeEventParam param)
	{
		Mechanism2072.ChaseSizeType @int = (Mechanism2072.ChaseSizeType)param.m_Int2;
		if (@int != Mechanism2072.ChaseSizeType.Big)
		{
			param.m_Int2 = 1;
		}
	}
}
