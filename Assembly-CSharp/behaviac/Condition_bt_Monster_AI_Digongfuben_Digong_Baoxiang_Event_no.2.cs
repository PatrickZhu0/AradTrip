using System;

namespace behaviac
{
	// Token: 0x02003239 RID: 12857
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node6 : Condition
	{
		// Token: 0x06014CF4 RID: 85236 RVA: 0x006451CD File Offset: 0x006435CD
		public Condition_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node6()
		{
			this.opl_p0 = 570205;
		}

		// Token: 0x06014CF5 RID: 85237 RVA: 0x006451E0 File Offset: 0x006435E0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_PlayerHaveBuff(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E64D RID: 58957
		private int opl_p0;
	}
}
