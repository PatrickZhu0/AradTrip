using System;

namespace behaviac
{
	// Token: 0x02003924 RID: 14628
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node21 : Condition
	{
		// Token: 0x06015A23 RID: 88611 RVA: 0x0068800B File Offset: 0x0068640B
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node21()
		{
			this.opl_p0 = 21458;
		}

		// Token: 0x06015A24 RID: 88612 RVA: 0x00688020 File Offset: 0x00686420
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F3B6 RID: 62390
		private int opl_p0;
	}
}
