using System;

namespace behaviac
{
	// Token: 0x02003275 RID: 12917
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Digongfuben_Digong_Tishi2_Event_node12 : Condition
	{
		// Token: 0x06014D66 RID: 85350 RVA: 0x006470C1 File Offset: 0x006454C1
		public Condition_bt_Monster_AI_Digongfuben_Digong_Tishi2_Event_node12()
		{
			this.opl_p0 = 570206;
		}

		// Token: 0x06014D67 RID: 85351 RVA: 0x006470D4 File Offset: 0x006454D4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_PlayerHaveBuff(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E68D RID: 59021
		private int opl_p0;
	}
}
