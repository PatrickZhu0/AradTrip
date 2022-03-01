using System;

namespace behaviac
{
	// Token: 0x020037E8 RID: 14312
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Sunshine_node1 : Condition
	{
		// Token: 0x060157C8 RID: 88008 RVA: 0x0067C3F8 File Offset: 0x0067A7F8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Conditon_IsDayTime();
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
