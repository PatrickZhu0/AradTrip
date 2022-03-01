using System;

namespace behaviac
{
	// Token: 0x020037F6 RID: 14326
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Shiyachong_Hard_node1 : Condition
	{
		// Token: 0x060157E1 RID: 88033 RVA: 0x0067CA6C File Offset: 0x0067AE6C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Conditon_IsDayTime();
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
