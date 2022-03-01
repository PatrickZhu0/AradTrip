using System;

namespace behaviac
{
	// Token: 0x02003CF0 RID: 15600
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Kexila_Liuchengkongzhi_Emeng_hard_node39 : Condition
	{
		// Token: 0x0601617F RID: 90495 RVA: 0x006ADE80 File Offset: 0x006AC280
		public Condition_bt_Monster_AI_Tuanben_hard_Kexila_Liuchengkongzhi_Emeng_hard_node39()
		{
			this.opl_p0 = ServerNotifyMessageId.HARDCthyllaNightmare;
		}

		// Token: 0x06016180 RID: 90496 RVA: 0x006ADE90 File Offset: 0x006AC290
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_ServerNotify(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA1E RID: 64030
		private ServerNotifyMessageId opl_p0;
	}
}
