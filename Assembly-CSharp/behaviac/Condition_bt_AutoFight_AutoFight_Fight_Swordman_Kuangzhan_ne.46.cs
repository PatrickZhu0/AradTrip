using System;

namespace behaviac
{
	// Token: 0x020023CE RID: 9166
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node15 : Condition
	{
		// Token: 0x06013102 RID: 78082 RVA: 0x005A58E3 File Offset: 0x005A3CE3
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node15()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06013103 RID: 78083 RVA: 0x005A5918 File Offset: 0x005A3D18
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CB34 RID: 52020
		private int opl_p0;

		// Token: 0x0400CB35 RID: 52021
		private int opl_p1;

		// Token: 0x0400CB36 RID: 52022
		private int opl_p2;

		// Token: 0x0400CB37 RID: 52023
		private int opl_p3;
	}
}
