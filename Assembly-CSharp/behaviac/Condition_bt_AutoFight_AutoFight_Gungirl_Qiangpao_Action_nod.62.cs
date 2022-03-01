using System;

namespace behaviac
{
	// Token: 0x02002565 RID: 9573
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node114 : Condition
	{
		// Token: 0x06013413 RID: 78867 RVA: 0x005B7E63 File Offset: 0x005B6263
		public Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node114()
		{
			this.opl_p0 = 3500;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06013414 RID: 78868 RVA: 0x005B7E98 File Offset: 0x005B6298
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CE38 RID: 52792
		private int opl_p0;

		// Token: 0x0400CE39 RID: 52793
		private int opl_p1;

		// Token: 0x0400CE3A RID: 52794
		private int opl_p2;

		// Token: 0x0400CE3B RID: 52795
		private int opl_p3;
	}
}
