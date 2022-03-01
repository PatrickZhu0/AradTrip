using System;

namespace behaviac
{
	// Token: 0x02003CA8 RID: 15528
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node68 : Condition
	{
		// Token: 0x060160F7 RID: 90359 RVA: 0x006AA3AE File Offset: 0x006A87AE
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node68()
		{
			this.opl_p0 = 6700;
			this.opl_p1 = 2000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x060160F8 RID: 90360 RVA: 0x006AA3E4 File Offset: 0x006A87E4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F99D RID: 63901
		private int opl_p0;

		// Token: 0x0400F99E RID: 63902
		private int opl_p1;

		// Token: 0x0400F99F RID: 63903
		private int opl_p2;

		// Token: 0x0400F9A0 RID: 63904
		private int opl_p3;
	}
}
