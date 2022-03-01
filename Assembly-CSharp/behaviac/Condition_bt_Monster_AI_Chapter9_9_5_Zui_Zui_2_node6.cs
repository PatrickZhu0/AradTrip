using System;

namespace behaviac
{
	// Token: 0x020031E7 RID: 12775
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_5_Zui_Zui_2_node6 : Condition
	{
		// Token: 0x06014C5B RID: 85083 RVA: 0x00642084 File Offset: 0x00640484
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Conditon_IsDayTime();
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
