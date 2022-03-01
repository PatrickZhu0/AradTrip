using System;

namespace behaviac
{
	// Token: 0x02003755 RID: 14165
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node77 : Condition
	{
		// Token: 0x060156B1 RID: 87729 RVA: 0x00676413 File Offset: 0x00674813
		public Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node77()
		{
			this.opl_p0 = 21194;
		}

		// Token: 0x060156B2 RID: 87730 RVA: 0x00676428 File Offset: 0x00674828
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F086 RID: 61574
		private int opl_p0;
	}
}
