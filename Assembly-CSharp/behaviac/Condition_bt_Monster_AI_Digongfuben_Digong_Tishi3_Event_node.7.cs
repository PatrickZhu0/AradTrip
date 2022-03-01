using System;

namespace behaviac
{
	// Token: 0x02003288 RID: 12936
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Digongfuben_Digong_Tishi3_Event_node8 : Condition
	{
		// Token: 0x06014D8B RID: 85387 RVA: 0x00647869 File Offset: 0x00645C69
		public Condition_bt_Monster_AI_Digongfuben_Digong_Tishi3_Event_node8()
		{
			this.opl_p0 = 570172;
		}

		// Token: 0x06014D8C RID: 85388 RVA: 0x0064787C File Offset: 0x00645C7C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_PlayerHaveBuff(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E695 RID: 59029
		private int opl_p0;
	}
}
