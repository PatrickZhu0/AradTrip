using System;

namespace behaviac
{
	// Token: 0x0200392A RID: 14634
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node34 : Condition
	{
		// Token: 0x06015A2F RID: 88623 RVA: 0x00688283 File Offset: 0x00686683
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node34()
		{
			this.opl_p0 = 21460;
		}

		// Token: 0x06015A30 RID: 88624 RVA: 0x00688298 File Offset: 0x00686698
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F3BE RID: 62398
		private int opl_p0;
	}
}
