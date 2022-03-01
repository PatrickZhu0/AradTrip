using System;

namespace behaviac
{
	// Token: 0x0200393C RID: 14652
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node50 : Condition
	{
		// Token: 0x06015A53 RID: 88659 RVA: 0x00688A3B File Offset: 0x00686E3B
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node50()
		{
			this.opl_p0 = 21458;
		}

		// Token: 0x06015A54 RID: 88660 RVA: 0x00688A50 File Offset: 0x00686E50
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F3E2 RID: 62434
		private int opl_p0;
	}
}
