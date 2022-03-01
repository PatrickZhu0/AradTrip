using System;

namespace behaviac
{
	// Token: 0x020021F3 RID: 8691
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_veryhard_Action_node23 : Condition
	{
		// Token: 0x06012D73 RID: 77171 RVA: 0x0058BBAF File Offset: 0x00589FAF
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_veryhard_Action_node23()
		{
			this.opl_p0 = 3500;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06012D74 RID: 77172 RVA: 0x0058BBE4 File Offset: 0x00589FE4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C765 RID: 51045
		private int opl_p0;

		// Token: 0x0400C766 RID: 51046
		private int opl_p1;

		// Token: 0x0400C767 RID: 51047
		private int opl_p2;

		// Token: 0x0400C768 RID: 51048
		private int opl_p3;
	}
}
