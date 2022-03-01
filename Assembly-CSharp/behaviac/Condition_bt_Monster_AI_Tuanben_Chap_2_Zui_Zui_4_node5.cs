using System;

namespace behaviac
{
	// Token: 0x0200380F RID: 14351
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node5 : Condition
	{
		// Token: 0x0601580E RID: 88078 RVA: 0x0067D69C File Offset: 0x0067BA9C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Conditon_IsDayTime();
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
