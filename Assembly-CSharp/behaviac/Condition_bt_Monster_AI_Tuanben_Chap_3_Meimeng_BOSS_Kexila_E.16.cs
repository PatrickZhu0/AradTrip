using System;

namespace behaviac
{
	// Token: 0x02003976 RID: 14710
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node22 : Condition
	{
		// Token: 0x06015AC4 RID: 88772 RVA: 0x0068B7A8 File Offset: 0x00689BA8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 1;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
