using System;

namespace behaviac
{
	// Token: 0x02002554 RID: 9556
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node92 : Condition
	{
		// Token: 0x060133F1 RID: 78833 RVA: 0x005B774A File Offset: 0x005B5B4A
		public Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node92()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x060133F2 RID: 78834 RVA: 0x005B7780 File Offset: 0x005B5B80
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CE17 RID: 52759
		private int opl_p0;

		// Token: 0x0400CE18 RID: 52760
		private int opl_p1;

		// Token: 0x0400CE19 RID: 52761
		private int opl_p2;

		// Token: 0x0400CE1A RID: 52762
		private int opl_p3;
	}
}
