using System;

namespace behaviac
{
	// Token: 0x0200204B RID: 8267
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_normal_Action_node23 : Condition
	{
		// Token: 0x06012A30 RID: 76336 RVA: 0x00577657 File Offset: 0x00575A57
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_normal_Action_node23()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012A31 RID: 76337 RVA: 0x0057768C File Offset: 0x00575A8C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C422 RID: 50210
		private int opl_p0;

		// Token: 0x0400C423 RID: 50211
		private int opl_p1;

		// Token: 0x0400C424 RID: 50212
		private int opl_p2;

		// Token: 0x0400C425 RID: 50213
		private int opl_p3;
	}
}
