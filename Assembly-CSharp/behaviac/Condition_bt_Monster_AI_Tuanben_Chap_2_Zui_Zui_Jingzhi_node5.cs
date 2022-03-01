using System;

namespace behaviac
{
	// Token: 0x02003823 RID: 14371
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_Jingzhi_node5 : Condition
	{
		// Token: 0x06015834 RID: 88116 RVA: 0x0067E1D0 File Offset: 0x0067C5D0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Conditon_IsDayTime();
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
