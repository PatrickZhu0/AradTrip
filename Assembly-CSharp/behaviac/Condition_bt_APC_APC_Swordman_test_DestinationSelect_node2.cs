using System;

namespace behaviac
{
	// Token: 0x02001E0D RID: 7693
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Swordman_test_DestinationSelect_node2 : Condition
	{
		// Token: 0x060125CC RID: 75212 RVA: 0x0055D4B2 File Offset: 0x0055B8B2
		public Condition_bt_APC_APC_Swordman_test_DestinationSelect_node2()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x060125CD RID: 75213 RVA: 0x0055D4D0 File Offset: 0x0055B8D0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BFB8 RID: 49080
		private BE_Target opl_p0;

		// Token: 0x0400BFB9 RID: 49081
		private BE_Equal opl_p1;

		// Token: 0x0400BFBA RID: 49082
		private BE_State opl_p2;
	}
}
