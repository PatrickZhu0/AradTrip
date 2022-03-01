using System;

namespace behaviac
{
	// Token: 0x02003191 RID: 12689
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_5_2_Zui_Kexilazhiyan_Shihuatai_node0 : Condition
	{
		// Token: 0x06014BB9 RID: 84921 RVA: 0x0063E8F0 File Offset: 0x0063CCF0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Conditon_IsDayTime();
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
