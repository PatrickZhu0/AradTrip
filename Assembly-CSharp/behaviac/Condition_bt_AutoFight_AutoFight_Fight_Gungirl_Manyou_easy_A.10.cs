using System;

namespace behaviac
{
	// Token: 0x02001FD0 RID: 8144
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_easy_Action_node23 : Condition
	{
		// Token: 0x0601293D RID: 76093 RVA: 0x00571953 File Offset: 0x0056FD53
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_easy_Action_node23()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x0601293E RID: 76094 RVA: 0x00571988 File Offset: 0x0056FD88
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C32E RID: 49966
		private int opl_p0;

		// Token: 0x0400C32F RID: 49967
		private int opl_p1;

		// Token: 0x0400C330 RID: 49968
		private int opl_p2;

		// Token: 0x0400C331 RID: 49969
		private int opl_p3;
	}
}
