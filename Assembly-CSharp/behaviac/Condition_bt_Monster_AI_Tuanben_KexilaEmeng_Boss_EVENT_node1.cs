using System;

namespace behaviac
{
	// Token: 0x020039F8 RID: 14840
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_EVENT_node15 : Condition
	{
		// Token: 0x06015BBE RID: 89022 RVA: 0x00690B0F File Offset: 0x0068EF0F
		public Condition_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_EVENT_node15()
		{
			this.opl_p0 = 21159;
		}

		// Token: 0x06015BBF RID: 89023 RVA: 0x00690B24 File Offset: 0x0068EF24
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckIsUsingSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F4F0 RID: 62704
		private int opl_p0;
	}
}
