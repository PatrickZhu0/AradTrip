using System;

namespace behaviac
{
	// Token: 0x02003981 RID: 14721
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node10 : Condition
	{
		// Token: 0x06015ADA RID: 88794 RVA: 0x0068BAF4 File Offset: 0x00689EF4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 3;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
