using System;

namespace behaviac
{
	// Token: 0x02002534 RID: 9524
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node1 : Condition
	{
		// Token: 0x060133B1 RID: 78769 RVA: 0x005B699E File Offset: 0x005B4D9E
		public Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node1()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x060133B2 RID: 78770 RVA: 0x005B69D4 File Offset: 0x005B4DD4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CDD7 RID: 52695
		private int opl_p0;

		// Token: 0x0400CDD8 RID: 52696
		private int opl_p1;

		// Token: 0x0400CDD9 RID: 52697
		private int opl_p2;

		// Token: 0x0400CDDA RID: 52698
		private int opl_p3;
	}
}
