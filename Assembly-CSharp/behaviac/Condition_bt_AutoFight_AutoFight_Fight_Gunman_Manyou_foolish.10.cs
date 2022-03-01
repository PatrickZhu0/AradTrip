using System;

namespace behaviac
{
	// Token: 0x0200213B RID: 8507
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_foolish_Action_node23 : Condition
	{
		// Token: 0x06012C08 RID: 76808 RVA: 0x00582EC7 File Offset: 0x005812C7
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_foolish_Action_node23()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012C09 RID: 76809 RVA: 0x00582EFC File Offset: 0x005812FC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C5FA RID: 50682
		private int opl_p0;

		// Token: 0x0400C5FB RID: 50683
		private int opl_p1;

		// Token: 0x0400C5FC RID: 50684
		private int opl_p2;

		// Token: 0x0400C5FD RID: 50685
		private int opl_p3;
	}
}
