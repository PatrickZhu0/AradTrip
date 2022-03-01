using System;

namespace behaviac
{
	// Token: 0x02001E77 RID: 7799
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Kuangzhan2_Action_DestinationSelect_node52 : Condition
	{
		// Token: 0x06012699 RID: 75417 RVA: 0x00562477 File Offset: 0x00560877
		public Condition_bt_APC_ShenyuanAPC_Kuangzhan2_Action_DestinationSelect_node52()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x0601269A RID: 75418 RVA: 0x00562494 File Offset: 0x00560894
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C080 RID: 49280
		private BE_Target opl_p0;

		// Token: 0x0400C081 RID: 49281
		private BE_Equal opl_p1;

		// Token: 0x0400C082 RID: 49282
		private BE_State opl_p2;
	}
}
