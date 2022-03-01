using System;

namespace behaviac
{
	// Token: 0x020037F1 RID: 14321
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Shiyachong_node1 : Condition
	{
		// Token: 0x060157D8 RID: 88024 RVA: 0x0067C81C File Offset: 0x0067AC1C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Conditon_IsDayTime();
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
