using System;

namespace behaviac
{
	// Token: 0x02002550 RID: 9552
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node88 : Condition
	{
		// Token: 0x060133E9 RID: 78825 RVA: 0x005B7596 File Offset: 0x005B5996
		public Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node88()
		{
			this.opl_p0 = 2500;
			this.opl_p1 = 500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x060133EA RID: 78826 RVA: 0x005B75CC File Offset: 0x005B59CC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CE0F RID: 52751
		private int opl_p0;

		// Token: 0x0400CE10 RID: 52752
		private int opl_p1;

		// Token: 0x0400CE11 RID: 52753
		private int opl_p2;

		// Token: 0x0400CE12 RID: 52754
		private int opl_p3;
	}
}
