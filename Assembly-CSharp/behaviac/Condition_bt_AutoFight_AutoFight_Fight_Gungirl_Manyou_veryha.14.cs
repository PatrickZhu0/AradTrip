using System;

namespace behaviac
{
	// Token: 0x0200207B RID: 8315
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_veryhard_Action_node33 : Condition
	{
		// Token: 0x06012A8F RID: 76431 RVA: 0x0057985B File Offset: 0x00577C5B
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_veryhard_Action_node33()
		{
			this.opl_p0 = 1800;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012A90 RID: 76432 RVA: 0x00579890 File Offset: 0x00577C90
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C481 RID: 50305
		private int opl_p0;

		// Token: 0x0400C482 RID: 50306
		private int opl_p1;

		// Token: 0x0400C483 RID: 50307
		private int opl_p2;

		// Token: 0x0400C484 RID: 50308
		private int opl_p3;
	}
}
