using System;

namespace behaviac
{
	// Token: 0x02003294 RID: 12948
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node8 : Condition
	{
		// Token: 0x06014DA2 RID: 85410 RVA: 0x00647E8D File Offset: 0x0064628D
		public Condition_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node8()
		{
			this.opl_p0 = 570173;
		}

		// Token: 0x06014DA3 RID: 85411 RVA: 0x00647EA0 File Offset: 0x006462A0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_PlayerHaveBuff(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E69B RID: 59035
		private int opl_p0;
	}
}
