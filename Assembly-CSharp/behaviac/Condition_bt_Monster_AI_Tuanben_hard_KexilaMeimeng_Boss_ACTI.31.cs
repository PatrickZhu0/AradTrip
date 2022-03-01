using System;

namespace behaviac
{
	// Token: 0x02003C36 RID: 15414
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_Shenyuan_node28 : Condition
	{
		// Token: 0x06016017 RID: 90135 RVA: 0x006A678C File Offset: 0x006A4B8C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 1;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
