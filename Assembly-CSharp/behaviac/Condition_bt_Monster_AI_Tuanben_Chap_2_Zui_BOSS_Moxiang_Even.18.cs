using System;

namespace behaviac
{
	// Token: 0x020037AC RID: 14252
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Event_Hard_node14 : Condition
	{
		// Token: 0x0601575B RID: 87899 RVA: 0x00679FB0 File Offset: 0x006783B0
		public Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Event_Hard_node14()
		{
			this.opl_p0 = 21189;
		}

		// Token: 0x0601575C RID: 87900 RVA: 0x00679FC4 File Offset: 0x006783C4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckIsUsingSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F109 RID: 61705
		private int opl_p0;
	}
}
