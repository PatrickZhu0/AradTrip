using System;

namespace behaviac
{
	// Token: 0x02002548 RID: 9544
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node80 : Condition
	{
		// Token: 0x060133D9 RID: 78809 RVA: 0x005B722E File Offset: 0x005B562E
		public Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node80()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x060133DA RID: 78810 RVA: 0x005B7264 File Offset: 0x005B5664
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CDFF RID: 52735
		private int opl_p0;

		// Token: 0x0400CE00 RID: 52736
		private int opl_p1;

		// Token: 0x0400CE01 RID: 52737
		private int opl_p2;

		// Token: 0x0400CE02 RID: 52738
		private int opl_p3;
	}
}
