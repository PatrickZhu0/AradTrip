using System;

namespace behaviac
{
	// Token: 0x02001FEB RID: 8171
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_foolish_Action_node3 : Condition
	{
		// Token: 0x06012972 RID: 76146 RVA: 0x00573213 File Offset: 0x00571613
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_foolish_Action_node3()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06012973 RID: 76147 RVA: 0x00573248 File Offset: 0x00571648
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C364 RID: 50020
		private int opl_p0;

		// Token: 0x0400C365 RID: 50021
		private int opl_p1;

		// Token: 0x0400C366 RID: 50022
		private int opl_p2;

		// Token: 0x0400C367 RID: 50023
		private int opl_p3;
	}
}
