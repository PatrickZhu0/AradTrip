using System;

namespace behaviac
{
	// Token: 0x02003270 RID: 12912
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Digongfuben_Digong_Tishi1_Event_node8 : Condition
	{
		// Token: 0x06014D5D RID: 85341 RVA: 0x00646C21 File Offset: 0x00645021
		public Condition_bt_Monster_AI_Digongfuben_Digong_Tishi1_Event_node8()
		{
			this.opl_p0 = 570205;
		}

		// Token: 0x06014D5E RID: 85342 RVA: 0x00646C34 File Offset: 0x00645034
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_PlayerHaveBuff(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E689 RID: 59017
		private int opl_p0;
	}
}
