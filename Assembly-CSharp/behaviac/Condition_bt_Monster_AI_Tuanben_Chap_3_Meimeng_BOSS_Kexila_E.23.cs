using System;

namespace behaviac
{
	// Token: 0x02003985 RID: 14725
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node31 : Condition
	{
		// Token: 0x06015AE2 RID: 88802 RVA: 0x0068BC00 File Offset: 0x0068A000
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 4;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
