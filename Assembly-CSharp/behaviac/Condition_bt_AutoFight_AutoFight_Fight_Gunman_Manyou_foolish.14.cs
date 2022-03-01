using System;

namespace behaviac
{
	// Token: 0x02002143 RID: 8515
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_foolish_Action_node33 : Condition
	{
		// Token: 0x06012C18 RID: 76824 RVA: 0x005832AF File Offset: 0x005816AF
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_foolish_Action_node33()
		{
			this.opl_p0 = 1800;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012C19 RID: 76825 RVA: 0x005832E4 File Offset: 0x005816E4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C60A RID: 50698
		private int opl_p0;

		// Token: 0x0400C60B RID: 50699
		private int opl_p1;

		// Token: 0x0400C60C RID: 50700
		private int opl_p2;

		// Token: 0x0400C60D RID: 50701
		private int opl_p3;
	}
}
