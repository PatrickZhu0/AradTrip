using System;

namespace behaviac
{
	// Token: 0x0200375C RID: 14172
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node18 : Condition
	{
		// Token: 0x060156BF RID: 87743 RVA: 0x006766EB File Offset: 0x00674AEB
		public Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node18()
		{
			this.opl_p0 = 21188;
		}

		// Token: 0x060156C0 RID: 87744 RVA: 0x00676700 File Offset: 0x00674B00
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F091 RID: 61585
		private int opl_p0;
	}
}
