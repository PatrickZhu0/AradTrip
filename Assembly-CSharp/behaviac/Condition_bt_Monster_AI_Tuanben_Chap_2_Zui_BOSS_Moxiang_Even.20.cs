using System;

namespace behaviac
{
	// Token: 0x020037AF RID: 14255
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Event_Hard_node27 : Condition
	{
		// Token: 0x06015762 RID: 87906 RVA: 0x0067A0F4 File Offset: 0x006784F4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Conditon_IsDayTime();
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
