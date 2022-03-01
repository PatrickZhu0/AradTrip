using System;

namespace behaviac
{
	// Token: 0x02002538 RID: 9528
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node34 : Condition
	{
		// Token: 0x060133B9 RID: 78777 RVA: 0x005B6B56 File Offset: 0x005B4F56
		public Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node34()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x060133BA RID: 78778 RVA: 0x005B6B8C File Offset: 0x005B4F8C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CDDF RID: 52703
		private int opl_p0;

		// Token: 0x0400CDE0 RID: 52704
		private int opl_p1;

		// Token: 0x0400CDE1 RID: 52705
		private int opl_p2;

		// Token: 0x0400CDE2 RID: 52706
		private int opl_p3;
	}
}
