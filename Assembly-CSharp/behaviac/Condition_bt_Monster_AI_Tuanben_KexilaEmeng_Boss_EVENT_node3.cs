using System;

namespace behaviac
{
	// Token: 0x020039F7 RID: 14839
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_EVENT_node39 : Condition
	{
		// Token: 0x06015BBC RID: 89020 RVA: 0x00690ACB File Offset: 0x0068EECB
		public Condition_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_EVENT_node39()
		{
			this.opl_p0 = ServerNotifyMessageId.CthyllaNightmare;
		}

		// Token: 0x06015BBD RID: 89021 RVA: 0x00690ADC File Offset: 0x0068EEDC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_ServerNotify(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F4EF RID: 62703
		private ServerNotifyMessageId opl_p0;
	}
}
