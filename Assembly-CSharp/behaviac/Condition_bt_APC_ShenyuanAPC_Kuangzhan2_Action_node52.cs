using System;

namespace behaviac
{
	// Token: 0x02001E60 RID: 7776
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Kuangzhan2_Action_node52 : Condition
	{
		// Token: 0x0601266C RID: 75372 RVA: 0x005611EB File Offset: 0x0055F5EB
		public Condition_bt_APC_ShenyuanAPC_Kuangzhan2_Action_node52()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x0601266D RID: 75373 RVA: 0x00561208 File Offset: 0x0055F608
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C053 RID: 49235
		private BE_Target opl_p0;

		// Token: 0x0400C054 RID: 49236
		private BE_Equal opl_p1;

		// Token: 0x0400C055 RID: 49237
		private BE_State opl_p2;
	}
}
