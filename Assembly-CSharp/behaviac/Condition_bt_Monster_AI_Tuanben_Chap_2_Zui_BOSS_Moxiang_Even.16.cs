using System;

namespace behaviac
{
	// Token: 0x020037A9 RID: 14249
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Event_Hard_node21 : Condition
	{
		// Token: 0x06015755 RID: 87893 RVA: 0x00679E82 File Offset: 0x00678282
		public Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Event_Hard_node21()
		{
			this.opl_p0 = 21189;
		}

		// Token: 0x06015756 RID: 87894 RVA: 0x00679E98 File Offset: 0x00678298
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F106 RID: 61702
		private int opl_p0;
	}
}
