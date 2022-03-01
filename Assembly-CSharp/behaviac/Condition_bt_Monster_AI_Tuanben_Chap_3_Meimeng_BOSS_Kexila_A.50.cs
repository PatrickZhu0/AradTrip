using System;

namespace behaviac
{
	// Token: 0x0200391B RID: 14619
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node14 : Condition
	{
		// Token: 0x06015A11 RID: 88593 RVA: 0x00687C57 File Offset: 0x00686057
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node14()
		{
			this.opl_p0 = 21209;
		}

		// Token: 0x06015A12 RID: 88594 RVA: 0x00687C6C File Offset: 0x0068606C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F3AA RID: 62378
		private int opl_p0;
	}
}
