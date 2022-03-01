using System;

namespace behaviac
{
	// Token: 0x02003920 RID: 14624
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node13 : Condition
	{
		// Token: 0x06015A1B RID: 88603 RVA: 0x00687E86 File Offset: 0x00686286
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node13()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x06015A1C RID: 88604 RVA: 0x00687E9C File Offset: 0x0068629C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F3B1 RID: 62385
		private float opl_p0;
	}
}
