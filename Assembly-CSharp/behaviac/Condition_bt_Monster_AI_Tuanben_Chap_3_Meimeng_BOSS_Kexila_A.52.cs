using System;

namespace behaviac
{
	// Token: 0x0200391E RID: 14622
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node15 : Condition
	{
		// Token: 0x06015A17 RID: 88599 RVA: 0x00687D93 File Offset: 0x00686193
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node15()
		{
			this.opl_p0 = 21208;
		}

		// Token: 0x06015A18 RID: 88600 RVA: 0x00687DA8 File Offset: 0x006861A8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F3AE RID: 62382
		private int opl_p0;
	}
}
