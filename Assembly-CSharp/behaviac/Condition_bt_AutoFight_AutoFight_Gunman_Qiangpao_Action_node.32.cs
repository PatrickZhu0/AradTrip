using System;

namespace behaviac
{
	// Token: 0x02002667 RID: 9831
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node49 : Condition
	{
		// Token: 0x06013613 RID: 79379 RVA: 0x005C4673 File Offset: 0x005C2A73
		public Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node49()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x06013614 RID: 79380 RVA: 0x005C4690 File Offset: 0x005C2A90
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D064 RID: 53348
		private BE_Target opl_p0;

		// Token: 0x0400D065 RID: 53349
		private BE_Equal opl_p1;

		// Token: 0x0400D066 RID: 53350
		private BE_State opl_p2;
	}
}
