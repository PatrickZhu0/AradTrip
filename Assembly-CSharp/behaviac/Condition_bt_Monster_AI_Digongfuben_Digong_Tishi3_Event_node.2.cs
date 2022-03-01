using System;

namespace behaviac
{
	// Token: 0x02003281 RID: 12929
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Digongfuben_Digong_Tishi3_Event_node12 : Condition
	{
		// Token: 0x06014D7D RID: 85373 RVA: 0x006476E5 File Offset: 0x00645AE5
		public Condition_bt_Monster_AI_Digongfuben_Digong_Tishi3_Event_node12()
		{
			this.opl_p0 = 570172;
		}

		// Token: 0x06014D7E RID: 85374 RVA: 0x006476F8 File Offset: 0x00645AF8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_PlayerHaveBuff(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E693 RID: 59027
		private int opl_p0;
	}
}
