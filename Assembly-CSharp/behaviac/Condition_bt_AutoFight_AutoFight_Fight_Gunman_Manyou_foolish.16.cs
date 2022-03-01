using System;

namespace behaviac
{
	// Token: 0x02002147 RID: 8519
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_foolish_Action_node38 : Condition
	{
		// Token: 0x06012C20 RID: 76832 RVA: 0x0058344B File Offset: 0x0058184B
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_foolish_Action_node38()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06012C21 RID: 76833 RVA: 0x00583480 File Offset: 0x00581880
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C612 RID: 50706
		private int opl_p0;

		// Token: 0x0400C613 RID: 50707
		private int opl_p1;

		// Token: 0x0400C614 RID: 50708
		private int opl_p2;

		// Token: 0x0400C615 RID: 50709
		private int opl_p3;
	}
}
