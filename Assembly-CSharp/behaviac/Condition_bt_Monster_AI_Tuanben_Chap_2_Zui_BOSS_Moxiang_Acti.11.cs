using System;

namespace behaviac
{
	// Token: 0x02003758 RID: 14168
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node76 : Condition
	{
		// Token: 0x060156B7 RID: 87735 RVA: 0x0067654F File Offset: 0x0067494F
		public Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node76()
		{
			this.opl_p0 = 21188;
		}

		// Token: 0x060156B8 RID: 87736 RVA: 0x00676564 File Offset: 0x00674964
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F08A RID: 61578
		private int opl_p0;
	}
}
