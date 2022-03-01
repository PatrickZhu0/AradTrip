using System;

namespace behaviac
{
	// Token: 0x02003BE9 RID: 15337
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node39 : Condition
	{
		// Token: 0x06015F7F RID: 89983 RVA: 0x006A3093 File Offset: 0x006A1493
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node39()
		{
			this.opl_p0 = ServerNotifyMessageId.HARDCthyllaNightmare;
		}

		// Token: 0x06015F80 RID: 89984 RVA: 0x006A30A4 File Offset: 0x006A14A4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_ServerNotify(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F81A RID: 63514
		private ServerNotifyMessageId opl_p0;
	}
}
