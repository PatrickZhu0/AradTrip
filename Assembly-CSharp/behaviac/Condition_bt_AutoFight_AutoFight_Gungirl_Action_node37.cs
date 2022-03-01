using System;

namespace behaviac
{
	// Token: 0x020024BA RID: 9402
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Action_node37 : Condition
	{
		// Token: 0x060132BF RID: 78527 RVA: 0x005B0BB7 File Offset: 0x005AEFB7
		public Condition_bt_AutoFight_AutoFight_Gungirl_Action_node37()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x060132C0 RID: 78528 RVA: 0x005B0BEC File Offset: 0x005AEFEC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CCD8 RID: 52440
		private int opl_p0;

		// Token: 0x0400CCD9 RID: 52441
		private int opl_p1;

		// Token: 0x0400CCDA RID: 52442
		private int opl_p2;

		// Token: 0x0400CCDB RID: 52443
		private int opl_p3;
	}
}
