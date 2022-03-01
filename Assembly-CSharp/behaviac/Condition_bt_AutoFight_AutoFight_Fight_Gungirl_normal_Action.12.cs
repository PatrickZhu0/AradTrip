using System;

namespace behaviac
{
	// Token: 0x0200209F RID: 8351
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_normal_Action_node28 : Condition
	{
		// Token: 0x06012AD6 RID: 76502 RVA: 0x0057B5E7 File Offset: 0x005799E7
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_normal_Action_node28()
		{
			this.opl_p0 = 2500;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012AD7 RID: 76503 RVA: 0x0057B61C File Offset: 0x00579A1C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C4C8 RID: 50376
		private int opl_p0;

		// Token: 0x0400C4C9 RID: 50377
		private int opl_p1;

		// Token: 0x0400C4CA RID: 50378
		private int opl_p2;

		// Token: 0x0400C4CB RID: 50379
		private int opl_p3;
	}
}
