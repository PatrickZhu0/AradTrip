using System;

namespace behaviac
{
	// Token: 0x0200216B RID: 8555
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_hard_Action_node33 : Condition
	{
		// Token: 0x06012C67 RID: 76903 RVA: 0x005850CB File Offset: 0x005834CB
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_hard_Action_node33()
		{
			this.opl_p0 = 1800;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012C68 RID: 76904 RVA: 0x00585100 File Offset: 0x00583500
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C659 RID: 50777
		private int opl_p0;

		// Token: 0x0400C65A RID: 50778
		private int opl_p1;

		// Token: 0x0400C65B RID: 50779
		private int opl_p2;

		// Token: 0x0400C65C RID: 50780
		private int opl_p3;
	}
}
