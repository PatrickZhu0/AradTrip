using System;

namespace behaviac
{
	// Token: 0x020037D8 RID: 14296
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Kexilazhiyan_Shihuatai_node0 : Condition
	{
		// Token: 0x060157AC RID: 87980 RVA: 0x0067BB28 File Offset: 0x00679F28
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Conditon_IsDayTime();
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
