using System;

namespace behaviac
{
	// Token: 0x020031F0 RID: 12784
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_5_Zui_Zui_2_node13 : Condition
	{
		// Token: 0x06014C6D RID: 85101 RVA: 0x006423D0 File Offset: 0x006407D0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Conditon_IsDayTime();
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
