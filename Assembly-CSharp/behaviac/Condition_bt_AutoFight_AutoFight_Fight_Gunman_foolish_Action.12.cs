using System;

namespace behaviac
{
	// Token: 0x020020E7 RID: 8423
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_foolish_Action_node28 : Condition
	{
		// Token: 0x06012B63 RID: 76643 RVA: 0x0057EE27 File Offset: 0x0057D227
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_foolish_Action_node28()
		{
			this.opl_p0 = 3500;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012B64 RID: 76644 RVA: 0x0057EE5C File Offset: 0x0057D25C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C555 RID: 50517
		private int opl_p0;

		// Token: 0x0400C556 RID: 50518
		private int opl_p1;

		// Token: 0x0400C557 RID: 50519
		private int opl_p2;

		// Token: 0x0400C558 RID: 50520
		private int opl_p3;
	}
}
