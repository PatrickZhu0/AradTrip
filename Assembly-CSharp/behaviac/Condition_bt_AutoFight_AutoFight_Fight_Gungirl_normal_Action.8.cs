using System;

namespace behaviac
{
	// Token: 0x02002097 RID: 8343
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_normal_Action_node18 : Condition
	{
		// Token: 0x06012AC6 RID: 76486 RVA: 0x0057B1FF File Offset: 0x005795FF
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_normal_Action_node18()
		{
			this.opl_p0 = 1000;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012AC7 RID: 76487 RVA: 0x0057B234 File Offset: 0x00579634
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C4B8 RID: 50360
		private int opl_p0;

		// Token: 0x0400C4B9 RID: 50361
		private int opl_p1;

		// Token: 0x0400C4BA RID: 50362
		private int opl_p2;

		// Token: 0x0400C4BB RID: 50363
		private int opl_p3;
	}
}
