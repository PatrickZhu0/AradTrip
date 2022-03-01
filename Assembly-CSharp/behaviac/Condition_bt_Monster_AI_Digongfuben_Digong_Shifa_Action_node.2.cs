using System;

namespace behaviac
{
	// Token: 0x0200324D RID: 12877
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Action_node2 : Condition
	{
		// Token: 0x06014D1A RID: 85274 RVA: 0x00645B6B File Offset: 0x00643F6B
		public Condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Action_node2()
		{
			this.opl_p0 = 570172;
		}

		// Token: 0x06014D1B RID: 85275 RVA: 0x00645B80 File Offset: 0x00643F80
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_PlayerHaveBuff(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E668 RID: 58984
		private int opl_p0;
	}
}
