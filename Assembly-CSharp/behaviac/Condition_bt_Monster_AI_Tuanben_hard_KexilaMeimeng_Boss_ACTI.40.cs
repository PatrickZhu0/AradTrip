using System;

namespace behaviac
{
	// Token: 0x02003C43 RID: 15427
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_Shenyuan_node14 : Condition
	{
		// Token: 0x06016030 RID: 90160 RVA: 0x006A6CC2 File Offset: 0x006A50C2
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_Shenyuan_node14()
		{
			this.opl_p0 = 3500;
			this.opl_p1 = 2000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06016031 RID: 90161 RVA: 0x006A6CF8 File Offset: 0x006A50F8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F8A9 RID: 63657
		private int opl_p0;

		// Token: 0x0400F8AA RID: 63658
		private int opl_p1;

		// Token: 0x0400F8AB RID: 63659
		private int opl_p2;

		// Token: 0x0400F8AC RID: 63660
		private int opl_p3;
	}
}
