using System;

namespace behaviac
{
	// Token: 0x02003765 RID: 14181
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node54 : Condition
	{
		// Token: 0x060156D1 RID: 87761 RVA: 0x00676A9F File Offset: 0x00674E9F
		public Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node54()
		{
			this.opl_p0 = 21194;
		}

		// Token: 0x060156D2 RID: 87762 RVA: 0x00676AB4 File Offset: 0x00674EB4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F09D RID: 61597
		private int opl_p0;
	}
}
