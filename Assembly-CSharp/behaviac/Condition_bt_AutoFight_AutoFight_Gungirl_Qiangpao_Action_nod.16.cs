using System;

namespace behaviac
{
	// Token: 0x02002528 RID: 9512
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node51 : Condition
	{
		// Token: 0x06013399 RID: 78745 RVA: 0x005B642E File Offset: 0x005B482E
		public Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node51()
		{
			this.opl_p0 = 10000;
			this.opl_p1 = 500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x0601339A RID: 78746 RVA: 0x005B6464 File Offset: 0x005B4864
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CDBB RID: 52667
		private int opl_p0;

		// Token: 0x0400CDBC RID: 52668
		private int opl_p1;

		// Token: 0x0400CDBD RID: 52669
		private int opl_p2;

		// Token: 0x0400CDBE RID: 52670
		private int opl_p3;
	}
}
