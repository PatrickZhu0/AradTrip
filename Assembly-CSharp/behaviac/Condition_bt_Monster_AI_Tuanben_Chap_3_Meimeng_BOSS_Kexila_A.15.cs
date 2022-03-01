using System;

namespace behaviac
{
	// Token: 0x020038E6 RID: 14566
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_node30 : Condition
	{
		// Token: 0x060159A9 RID: 88489 RVA: 0x0068584B File Offset: 0x00683C4B
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_node30()
		{
			this.opl_p0 = 21205;
		}

		// Token: 0x060159AA RID: 88490 RVA: 0x00685860 File Offset: 0x00683C60
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F355 RID: 62293
		private int opl_p0;
	}
}
