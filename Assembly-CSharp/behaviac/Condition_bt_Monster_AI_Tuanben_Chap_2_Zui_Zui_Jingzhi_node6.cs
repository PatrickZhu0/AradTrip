using System;

namespace behaviac
{
	// Token: 0x02003821 RID: 14369
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_Jingzhi_node6 : Condition
	{
		// Token: 0x06015830 RID: 88112 RVA: 0x0067E160 File Offset: 0x0067C560
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Conditon_IsDayTime();
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
