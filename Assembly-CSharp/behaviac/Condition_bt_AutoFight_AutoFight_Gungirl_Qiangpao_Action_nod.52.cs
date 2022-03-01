using System;

namespace behaviac
{
	// Token: 0x02002558 RID: 9560
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node96 : Condition
	{
		// Token: 0x060133F9 RID: 78841 RVA: 0x005B78FE File Offset: 0x005B5CFE
		public Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node96()
		{
			this.opl_p0 = 1500;
			this.opl_p1 = 500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x060133FA RID: 78842 RVA: 0x005B7934 File Offset: 0x005B5D34
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CE1F RID: 52767
		private int opl_p0;

		// Token: 0x0400CE20 RID: 52768
		private int opl_p1;

		// Token: 0x0400CE21 RID: 52769
		private int opl_p2;

		// Token: 0x0400CE22 RID: 52770
		private int opl_p3;
	}
}
