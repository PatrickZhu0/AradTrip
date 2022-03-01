using System;

namespace behaviac
{
	// Token: 0x02003CF5 RID: 15605
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Kexila_Liuchengkongzhi_Emeng_hard_node10 : Condition
	{
		// Token: 0x06016189 RID: 90505 RVA: 0x006AE031 File Offset: 0x006AC431
		public Condition_bt_Monster_AI_Tuanben_hard_Kexila_Liuchengkongzhi_Emeng_hard_node10()
		{
			this.opl_p0 = ServerNotifyMessageId.HARDCthyllaSweetDream;
		}

		// Token: 0x0601618A RID: 90506 RVA: 0x006AE040 File Offset: 0x006AC440
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_ServerNotify(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA25 RID: 64037
		private ServerNotifyMessageId opl_p0;
	}
}
