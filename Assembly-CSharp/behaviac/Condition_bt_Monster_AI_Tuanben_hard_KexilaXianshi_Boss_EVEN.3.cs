using System;

namespace behaviac
{
	// Token: 0x02003CBC RID: 15548
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node58 : Condition
	{
		// Token: 0x0601611A RID: 90394 RVA: 0x006AC1C6 File Offset: 0x006AA5C6
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node58()
		{
			this.opl_p0 = 8001500;
		}

		// Token: 0x0601611B RID: 90395 RVA: 0x006AC1DC File Offset: 0x006AA5DC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_DungeonRecoverProcess(this.opl_p0);
			int num2 = 1000;
			bool flag = num < num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F9BD RID: 63933
		private int opl_p0;
	}
}
