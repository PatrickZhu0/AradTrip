using System;

namespace behaviac
{
	// Token: 0x020037FB RID: 14331
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Sunshine_node1 : Condition
	{
		// Token: 0x060157EA RID: 88042 RVA: 0x0067CCBC File Offset: 0x0067B0BC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Conditon_IsDayTime();
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
