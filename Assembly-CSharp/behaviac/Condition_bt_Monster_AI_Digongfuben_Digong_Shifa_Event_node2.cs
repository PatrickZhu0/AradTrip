using System;

namespace behaviac
{
	// Token: 0x02003260 RID: 12896
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node20 : Condition
	{
		// Token: 0x06014D3F RID: 85311 RVA: 0x006462F5 File Offset: 0x006446F5
		public Condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node20()
		{
			this.opl_p0 = 570172;
		}

		// Token: 0x06014D40 RID: 85312 RVA: 0x00646308 File Offset: 0x00644708
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_PlayerHaveBuff(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E680 RID: 59008
		private int opl_p0;
	}
}
