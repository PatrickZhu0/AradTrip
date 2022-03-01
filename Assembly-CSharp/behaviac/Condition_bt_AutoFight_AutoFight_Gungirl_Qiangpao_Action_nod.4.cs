using System;

namespace behaviac
{
	// Token: 0x02002518 RID: 9496
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node46 : Condition
	{
		// Token: 0x06013379 RID: 78713 RVA: 0x005B5D5E File Offset: 0x005B415E
		public Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node46()
		{
			this.opl_p0 = 8000;
			this.opl_p1 = 500;
			this.opl_p2 = 2500;
			this.opl_p3 = 2500;
		}

		// Token: 0x0601337A RID: 78714 RVA: 0x005B5D94 File Offset: 0x005B4194
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CD9B RID: 52635
		private int opl_p0;

		// Token: 0x0400CD9C RID: 52636
		private int opl_p1;

		// Token: 0x0400CD9D RID: 52637
		private int opl_p2;

		// Token: 0x0400CD9E RID: 52638
		private int opl_p3;
	}
}
