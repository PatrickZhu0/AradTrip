using System;
using GameClient;

// Token: 0x0200422D RID: 16941
public class Buff66 : BeBuff
{
	// Token: 0x0601773C RID: 96060 RVA: 0x00734C8A File Offset: 0x0073308A
	public Buff66(int bi, int buffLevel, int buffDuration, int attack = 0) : base(bi, buffLevel, buffDuration, attack, true)
	{
	}

	// Token: 0x0601773D RID: 96061 RVA: 0x00734C98 File Offset: 0x00733098
	public override void OnStart()
	{
		if (BeClientSwitch.FunctionIsOpen(ClientSwitchType.HideObjUseSetlayer))
		{
			base.owner.m_pkGeActor.GetEntityNode(GeEntity.GeEntityNodeType.Transform).SetLayer(19);
			if (base.owner.m_pkGeActor.goInfoBar != null)
			{
				base.owner.m_pkGeActor.goInfoBar.SetLayer(19);
			}
		}
		else
		{
			base.owner.m_pkGeActor.GetEntityNode(GeEntity.GeEntityNodeType.Transform).SetActive(false);
			base.owner.m_pkGeActor.SetHeadInfoVisible(false);
		}
	}

	// Token: 0x0601773E RID: 96062 RVA: 0x00734D28 File Offset: 0x00733128
	public override void OnFinish()
	{
		if (BeClientSwitch.FunctionIsOpen(ClientSwitchType.HideObjUseSetlayer))
		{
			base.owner.m_pkGeActor.GetEntityNode(GeEntity.GeEntityNodeType.Transform).SetLayer(0);
			if (base.owner.m_pkGeActor.goInfoBar != null)
			{
				base.owner.m_pkGeActor.goInfoBar.SetLayer(13);
			}
		}
		else
		{
			base.owner.m_pkGeActor.GetEntityNode(GeEntity.GeEntityNodeType.Transform).SetActive(true);
			base.owner.m_pkGeActor.SetHeadInfoVisible(true);
		}
	}
}
