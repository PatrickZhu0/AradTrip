using System;

namespace behaviac
{
	// Token: 0x02003C15 RID: 15381
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_node28 : Condition
	{
		// Token: 0x06015FD6 RID: 90070 RVA: 0x006A4E90 File Offset: 0x006A3290
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 1;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
