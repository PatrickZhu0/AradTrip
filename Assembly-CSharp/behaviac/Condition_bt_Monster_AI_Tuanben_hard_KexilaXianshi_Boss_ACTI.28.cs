using System;

namespace behaviac
{
	// Token: 0x02003C8C RID: 15500
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node23 : Condition
	{
		// Token: 0x060160BF RID: 90303 RVA: 0x006A971B File Offset: 0x006A7B1B
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node23()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 2000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x060160C0 RID: 90304 RVA: 0x006A9750 File Offset: 0x006A7B50
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F957 RID: 63831
		private int opl_p0;

		// Token: 0x0400F958 RID: 63832
		private int opl_p1;

		// Token: 0x0400F959 RID: 63833
		private int opl_p2;

		// Token: 0x0400F95A RID: 63834
		private int opl_p3;
	}
}
