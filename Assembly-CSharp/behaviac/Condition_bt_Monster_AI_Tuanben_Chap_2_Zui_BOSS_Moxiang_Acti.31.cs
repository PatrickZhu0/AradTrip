using System;

namespace behaviac
{
	// Token: 0x02003775 RID: 14197
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node86 : Condition
	{
		// Token: 0x060156F1 RID: 87793 RVA: 0x0067712B File Offset: 0x0067552B
		public Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node86()
		{
			this.opl_p0 = 21196;
		}

		// Token: 0x060156F2 RID: 87794 RVA: 0x00677140 File Offset: 0x00675540
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F0B4 RID: 61620
		private int opl_p0;
	}
}
