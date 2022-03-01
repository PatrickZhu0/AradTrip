using System;

namespace behaviac
{
	// Token: 0x02002544 RID: 9540
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node76 : Condition
	{
		// Token: 0x060133D1 RID: 78801 RVA: 0x005B707A File Offset: 0x005B547A
		public Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node76()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x060133D2 RID: 78802 RVA: 0x005B70B0 File Offset: 0x005B54B0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CDF7 RID: 52727
		private int opl_p0;

		// Token: 0x0400CDF8 RID: 52728
		private int opl_p1;

		// Token: 0x0400CDF9 RID: 52729
		private int opl_p2;

		// Token: 0x0400CDFA RID: 52730
		private int opl_p3;
	}
}
