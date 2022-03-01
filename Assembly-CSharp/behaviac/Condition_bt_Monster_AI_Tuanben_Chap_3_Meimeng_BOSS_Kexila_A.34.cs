using System;

namespace behaviac
{
	// Token: 0x02003905 RID: 14597
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node72 : Condition
	{
		// Token: 0x060159E5 RID: 88549 RVA: 0x0068731A File Offset: 0x0068571A
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node72()
		{
			this.opl_p0 = 0.16f;
		}

		// Token: 0x060159E6 RID: 88550 RVA: 0x00687330 File Offset: 0x00685730
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F383 RID: 62339
		private float opl_p0;
	}
}
