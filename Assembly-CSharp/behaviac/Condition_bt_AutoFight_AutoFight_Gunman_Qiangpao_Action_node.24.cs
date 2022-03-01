using System;

namespace behaviac
{
	// Token: 0x0200265D RID: 9821
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node3 : Condition
	{
		// Token: 0x060135FF RID: 79359 RVA: 0x005C41F3 File Offset: 0x005C25F3
		public Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node3()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x06013600 RID: 79360 RVA: 0x005C4210 File Offset: 0x005C2610
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D04E RID: 53326
		private BE_Target opl_p0;

		// Token: 0x0400D04F RID: 53327
		private BE_Equal opl_p1;

		// Token: 0x0400D050 RID: 53328
		private BE_State opl_p2;
	}
}
