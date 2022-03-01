using System;

namespace behaviac
{
	// Token: 0x02003C0F RID: 15375
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_node22 : Condition
	{
		// Token: 0x06015FCA RID: 90058 RVA: 0x006A4C78 File Offset: 0x006A3078
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 0;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
