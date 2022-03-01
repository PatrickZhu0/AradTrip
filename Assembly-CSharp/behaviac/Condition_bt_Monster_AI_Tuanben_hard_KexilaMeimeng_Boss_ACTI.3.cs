using System;

namespace behaviac
{
	// Token: 0x02003C08 RID: 15368
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_node39 : Condition
	{
		// Token: 0x06015FBB RID: 90043 RVA: 0x006A49F5 File Offset: 0x006A2DF5
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_node39()
		{
			this.opl_p0 = ServerNotifyMessageId.HARDCthyllaSweetDream;
		}

		// Token: 0x06015FBC RID: 90044 RVA: 0x006A4A04 File Offset: 0x006A2E04
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_ServerNotify(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F83E RID: 63550
		private ServerNotifyMessageId opl_p0;
	}
}
