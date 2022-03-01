using System;

namespace behaviac
{
	// Token: 0x02003269 RID: 12905
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Digongfuben_Digong_Tishi1_Event_node12 : Condition
	{
		// Token: 0x06014D4F RID: 85327 RVA: 0x00646A9D File Offset: 0x00644E9D
		public Condition_bt_Monster_AI_Digongfuben_Digong_Tishi1_Event_node12()
		{
			this.opl_p0 = 570205;
		}

		// Token: 0x06014D50 RID: 85328 RVA: 0x00646AB0 File Offset: 0x00644EB0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_PlayerHaveBuff(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E687 RID: 59015
		private int opl_p0;
	}
}
