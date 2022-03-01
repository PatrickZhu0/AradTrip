using System;

namespace behaviac
{
	// Token: 0x020031EB RID: 12779
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_5_Zui_Zui_2_node5 : Condition
	{
		// Token: 0x06014C63 RID: 85091 RVA: 0x0064222C File Offset: 0x0064062C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Conditon_IsDayTime();
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
