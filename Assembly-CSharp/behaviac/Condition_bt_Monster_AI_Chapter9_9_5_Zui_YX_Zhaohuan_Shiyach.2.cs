using System;

namespace behaviac
{
	// Token: 0x020031E3 RID: 12771
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_5_Zui_YX_Zhaohuan_Shiyachong_node4 : Condition
	{
		// Token: 0x06014C55 RID: 85077 RVA: 0x00641E90 File Offset: 0x00640290
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Conditon_IsDayTime();
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
