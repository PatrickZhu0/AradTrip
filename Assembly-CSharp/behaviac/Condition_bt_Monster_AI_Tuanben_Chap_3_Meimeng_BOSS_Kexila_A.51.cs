using System;

namespace behaviac
{
	// Token: 0x0200391D RID: 14621
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node10 : Condition
	{
		// Token: 0x06015A15 RID: 88597 RVA: 0x00687D4A File Offset: 0x0068614A
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node10()
		{
			this.opl_p0 = 0.16f;
		}

		// Token: 0x06015A16 RID: 88598 RVA: 0x00687D60 File Offset: 0x00686160
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F3AD RID: 62381
		private float opl_p0;
	}
}
