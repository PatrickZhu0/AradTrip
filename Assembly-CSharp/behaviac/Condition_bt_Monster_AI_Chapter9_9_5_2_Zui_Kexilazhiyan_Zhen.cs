using System;

namespace behaviac
{
	// Token: 0x02003195 RID: 12693
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_5_2_Zui_Kexilazhiyan_Zhengchangtai_node0 : Condition
	{
		// Token: 0x06014BC0 RID: 84928 RVA: 0x0063EB24 File Offset: 0x0063CF24
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Conditon_IsDayTime();
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
