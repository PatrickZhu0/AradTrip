using System;

namespace behaviac
{
	// Token: 0x02002037 RID: 8247
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_hard_Action_node48 : Condition
	{
		// Token: 0x06012A09 RID: 76297 RVA: 0x00576203 File Offset: 0x00574603
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_hard_Action_node48()
		{
			this.opl_p0 = 3500;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012A0A RID: 76298 RVA: 0x00576238 File Offset: 0x00574638
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C3FB RID: 50171
		private int opl_p0;

		// Token: 0x0400C3FC RID: 50172
		private int opl_p1;

		// Token: 0x0400C3FD RID: 50173
		private int opl_p2;

		// Token: 0x0400C3FE RID: 50174
		private int opl_p3;
	}
}
