using System;

namespace behaviac
{
	// Token: 0x02003C8F RID: 15503
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node26 : Condition
	{
		// Token: 0x060160C5 RID: 90309 RVA: 0x006A9886 File Offset: 0x006A7C86
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node26()
		{
			this.opl_p0 = 5500;
			this.opl_p1 = 2000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x060160C6 RID: 90310 RVA: 0x006A98BC File Offset: 0x006A7CBC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F95E RID: 63838
		private int opl_p0;

		// Token: 0x0400F95F RID: 63839
		private int opl_p1;

		// Token: 0x0400F960 RID: 63840
		private int opl_p2;

		// Token: 0x0400F961 RID: 63841
		private int opl_p3;
	}
}
