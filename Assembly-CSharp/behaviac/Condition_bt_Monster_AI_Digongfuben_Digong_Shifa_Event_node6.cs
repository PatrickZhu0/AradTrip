using System;

namespace behaviac
{
	// Token: 0x02003254 RID: 12884
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node6 : Condition
	{
		// Token: 0x06014D28 RID: 85288 RVA: 0x00645FFC File Offset: 0x006443FC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsAroundBossRomm();
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
