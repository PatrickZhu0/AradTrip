using System;

namespace behaviac
{
	// Token: 0x02003AAB RID: 15019
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node10 : Condition
	{
		// Token: 0x06015D18 RID: 89368 RVA: 0x00697AA1 File Offset: 0x00695EA1
		public Condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node10()
		{
			this.opl_p0 = ServerNotifyMessageId.CthyllaSweetDream;
		}

		// Token: 0x06015D19 RID: 89369 RVA: 0x00697AB0 File Offset: 0x00695EB0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_ServerNotify(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F63A RID: 63034
		private ServerNotifyMessageId opl_p0;
	}
}
