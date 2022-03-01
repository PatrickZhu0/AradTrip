using System;

namespace behaviac
{
	// Token: 0x02001D97 RID: 7575
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Kuangzhan2_Action_DestinationSelect_node52 : Condition
	{
		// Token: 0x060124E8 RID: 74984 RVA: 0x00557E13 File Offset: 0x00556213
		public Condition_bt_APC_APC_Kuangzhan2_Action_DestinationSelect_node52()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x060124E9 RID: 74985 RVA: 0x00557E30 File Offset: 0x00556230
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BED2 RID: 48850
		private BE_Target opl_p0;

		// Token: 0x0400BED3 RID: 48851
		private BE_Equal opl_p1;

		// Token: 0x0400BED4 RID: 48852
		private BE_State opl_p2;
	}
}
