using System;

namespace behaviac
{
	// Token: 0x020031F7 RID: 12791
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_5_Zui_Zui_2_node23 : Condition
	{
		// Token: 0x06014C7B RID: 85115 RVA: 0x00642600 File Offset: 0x00640A00
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Conditon_IsDayTime();
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
