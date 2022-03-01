using System;

namespace behaviac
{
	// Token: 0x02003A1C RID: 14876
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaMeimeng_Boss_ACTION_node39 : Condition
	{
		// Token: 0x06015C02 RID: 89090 RVA: 0x00691D9D File Offset: 0x0069019D
		public Condition_bt_Monster_AI_Tuanben_KexilaMeimeng_Boss_ACTION_node39()
		{
			this.opl_p0 = ServerNotifyMessageId.CthyllaSweetDream;
		}

		// Token: 0x06015C03 RID: 89091 RVA: 0x00691DAC File Offset: 0x006901AC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_ServerNotify(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F519 RID: 62745
		private ServerNotifyMessageId opl_p0;
	}
}
