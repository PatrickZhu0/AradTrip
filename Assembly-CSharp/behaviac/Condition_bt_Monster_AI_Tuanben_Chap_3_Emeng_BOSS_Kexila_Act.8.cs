using System;

namespace behaviac
{
	// Token: 0x02003843 RID: 14403
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_node53 : Condition
	{
		// Token: 0x0601586C RID: 88172 RVA: 0x0067F0EB File Offset: 0x0067D4EB
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_node53()
		{
			this.opl_p0 = 21213;
		}

		// Token: 0x0601586D RID: 88173 RVA: 0x0067F100 File Offset: 0x0067D500
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F22D RID: 61997
		private int opl_p0;
	}
}
