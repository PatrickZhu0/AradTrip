using System;

namespace behaviac
{
	// Token: 0x0200254C RID: 9548
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node84 : Condition
	{
		// Token: 0x060133E1 RID: 78817 RVA: 0x005B73E2 File Offset: 0x005B57E2
		public Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node84()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x060133E2 RID: 78818 RVA: 0x005B7418 File Offset: 0x005B5818
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CE07 RID: 52743
		private int opl_p0;

		// Token: 0x0400CE08 RID: 52744
		private int opl_p1;

		// Token: 0x0400CE09 RID: 52745
		private int opl_p2;

		// Token: 0x0400CE0A RID: 52746
		private int opl_p3;
	}
}
