using System;

namespace behaviac
{
	// Token: 0x02001FFF RID: 8191
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_foolish_Action_node28 : Condition
	{
		// Token: 0x0601299A RID: 76186 RVA: 0x00573B7F File Offset: 0x00571F7F
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_foolish_Action_node28()
		{
			this.opl_p0 = 1800;
			this.opl_p1 = 500;
			this.opl_p2 = 1800;
			this.opl_p3 = 1800;
		}

		// Token: 0x0601299B RID: 76187 RVA: 0x00573BB4 File Offset: 0x00571FB4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C38C RID: 50060
		private int opl_p0;

		// Token: 0x0400C38D RID: 50061
		private int opl_p1;

		// Token: 0x0400C38E RID: 50062
		private int opl_p2;

		// Token: 0x0400C38F RID: 50063
		private int opl_p3;
	}
}
