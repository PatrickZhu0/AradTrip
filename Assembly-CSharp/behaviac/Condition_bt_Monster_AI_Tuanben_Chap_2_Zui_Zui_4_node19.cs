using System;

namespace behaviac
{
	// Token: 0x02003813 RID: 14355
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node19 : Condition
	{
		// Token: 0x06015816 RID: 88086 RVA: 0x0067D794 File Offset: 0x0067BB94
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Conditon_IsDayTime();
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
