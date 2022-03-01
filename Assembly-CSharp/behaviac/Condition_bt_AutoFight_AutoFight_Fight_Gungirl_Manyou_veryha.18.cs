using System;

namespace behaviac
{
	// Token: 0x02002083 RID: 8323
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_veryhard_Action_node43 : Condition
	{
		// Token: 0x06012A9F RID: 76447 RVA: 0x00579CFB File Offset: 0x005780FB
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_veryhard_Action_node43()
		{
			this.opl_p0 = 3500;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06012AA0 RID: 76448 RVA: 0x00579D30 File Offset: 0x00578130
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C491 RID: 50321
		private int opl_p0;

		// Token: 0x0400C492 RID: 50322
		private int opl_p1;

		// Token: 0x0400C493 RID: 50323
		private int opl_p2;

		// Token: 0x0400C494 RID: 50324
		private int opl_p3;
	}
}
