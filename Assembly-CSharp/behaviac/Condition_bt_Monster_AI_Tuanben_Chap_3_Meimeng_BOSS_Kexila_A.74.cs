using System;

namespace behaviac
{
	// Token: 0x0200393F RID: 14655
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node54 : Condition
	{
		// Token: 0x06015A59 RID: 88665 RVA: 0x00688B77 File Offset: 0x00686F77
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node54()
		{
			this.opl_p0 = 21459;
		}

		// Token: 0x06015A5A RID: 88666 RVA: 0x00688B8C File Offset: 0x00686F8C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F3E6 RID: 62438
		private int opl_p0;
	}
}
