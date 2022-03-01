using System;

namespace behaviac
{
	// Token: 0x02002C50 RID: 11344
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_A_Event_node26 : Condition
	{
		// Token: 0x0601419C RID: 82332 RVA: 0x006091EE File Offset: 0x006075EE
		public Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_A_Event_node26()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521978;
		}

		// Token: 0x0601419D RID: 82333 RVA: 0x00609210 File Offset: 0x00607610
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DB62 RID: 56162
		private BE_Target opl_p0;

		// Token: 0x0400DB63 RID: 56163
		private BE_Equal opl_p1;

		// Token: 0x0400DB64 RID: 56164
		private int opl_p2;
	}
}
