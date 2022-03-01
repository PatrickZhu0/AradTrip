using System;

namespace behaviac
{
	// Token: 0x02003246 RID: 12870
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Digongfuben_Digong_Damowang_Event_node1 : Condition
	{
		// Token: 0x06014D0D RID: 85261 RVA: 0x006457FF File Offset: 0x00643BFF
		public Condition_bt_Monster_AI_Digongfuben_Digong_Damowang_Event_node1()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570219;
		}

		// Token: 0x06014D0E RID: 85262 RVA: 0x00645820 File Offset: 0x00643C20
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E65D RID: 58973
		private BE_Target opl_p0;

		// Token: 0x0400E65E RID: 58974
		private BE_Equal opl_p1;

		// Token: 0x0400E65F RID: 58975
		private int opl_p2;
	}
}
