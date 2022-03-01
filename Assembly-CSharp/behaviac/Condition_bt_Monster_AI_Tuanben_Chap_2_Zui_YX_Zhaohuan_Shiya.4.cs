using System;

namespace behaviac
{
	// Token: 0x020037F8 RID: 14328
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Shiyachong_Hard_node4 : Condition
	{
		// Token: 0x060157E5 RID: 88037 RVA: 0x0067CAEC File Offset: 0x0067AEEC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Conditon_IsDayTime();
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
