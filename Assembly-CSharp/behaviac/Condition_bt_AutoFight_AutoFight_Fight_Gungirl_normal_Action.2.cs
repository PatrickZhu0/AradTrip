using System;

namespace behaviac
{
	// Token: 0x0200208B RID: 8331
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_normal_Action_node3 : Condition
	{
		// Token: 0x06012AAE RID: 76462 RVA: 0x0057ABCB File Offset: 0x00578FCB
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_normal_Action_node3()
		{
			this.opl_p0 = 1500;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012AAF RID: 76463 RVA: 0x0057AC00 File Offset: 0x00579000
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C4A0 RID: 50336
		private int opl_p0;

		// Token: 0x0400C4A1 RID: 50337
		private int opl_p1;

		// Token: 0x0400C4A2 RID: 50338
		private int opl_p2;

		// Token: 0x0400C4A3 RID: 50339
		private int opl_p3;
	}
}
