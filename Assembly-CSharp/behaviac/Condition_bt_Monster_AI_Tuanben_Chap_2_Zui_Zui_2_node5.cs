using System;

namespace behaviac
{
	// Token: 0x02003804 RID: 14340
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node5 : Condition
	{
		// Token: 0x060157FA RID: 88058 RVA: 0x0067D068 File Offset: 0x0067B468
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Conditon_IsDayTime();
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
