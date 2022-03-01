using System;

namespace behaviac
{
	// Token: 0x02003795 RID: 14229
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Event_node13 : Condition
	{
		// Token: 0x06015730 RID: 87856 RVA: 0x00679298 File Offset: 0x00677698
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Conditon_IsDayTime();
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
