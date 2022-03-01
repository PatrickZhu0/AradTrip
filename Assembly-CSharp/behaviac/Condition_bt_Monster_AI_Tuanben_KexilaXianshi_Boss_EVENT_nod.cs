using System;

namespace behaviac
{
	// Token: 0x02003A87 RID: 14983
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_EVENT_node90 : Condition
	{
		// Token: 0x06015CD3 RID: 89299 RVA: 0x00696907 File Offset: 0x00694D07
		public Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_EVENT_node90()
		{
			this.opl_p0 = EventType.OnHurt;
		}

		// Token: 0x06015CD4 RID: 89300 RVA: 0x00696918 File Offset: 0x00694D18
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_HasReceiveEventNew(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F60B RID: 62987
		private EventType opl_p0;
	}
}
