using System;

namespace behaviac
{
	// Token: 0x02002662 RID: 9826
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node47 : Condition
	{
		// Token: 0x06013609 RID: 79369 RVA: 0x005C4463 File Offset: 0x005C2863
		public Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node47()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x0601360A RID: 79370 RVA: 0x005C4480 File Offset: 0x005C2880
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D059 RID: 53337
		private BE_Target opl_p0;

		// Token: 0x0400D05A RID: 53338
		private BE_Equal opl_p1;

		// Token: 0x0400D05B RID: 53339
		private BE_State opl_p2;
	}
}
