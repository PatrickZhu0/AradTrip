using System;

namespace behaviac
{
	// Token: 0x02001FF7 RID: 8183
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_foolish_Action_node18 : Condition
	{
		// Token: 0x0601298A RID: 76170 RVA: 0x00573797 File Offset: 0x00571B97
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_foolish_Action_node18()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x0601298B RID: 76171 RVA: 0x005737CC File Offset: 0x00571BCC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C37C RID: 50044
		private int opl_p0;

		// Token: 0x0400C37D RID: 50045
		private int opl_p1;

		// Token: 0x0400C37E RID: 50046
		private int opl_p2;

		// Token: 0x0400C37F RID: 50047
		private int opl_p3;
	}
}
