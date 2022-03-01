using System;

namespace behaviac
{
	// Token: 0x020037DC RID: 14300
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Kexilazhiyan_Shihuatai_Hard_node0 : Condition
	{
		// Token: 0x060157B3 RID: 87987 RVA: 0x0067BD5C File Offset: 0x0067A15C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Conditon_IsDayTime();
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
