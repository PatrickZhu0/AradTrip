using System;

namespace behaviac
{
	// Token: 0x02003BC6 RID: 15302
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node32 : Condition
	{
		// Token: 0x06015F39 RID: 89913 RVA: 0x006A263A File Offset: 0x006A0A3A
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node32()
		{
			this.opl_p0 = 8001500;
		}

		// Token: 0x06015F3A RID: 89914 RVA: 0x006A2650 File Offset: 0x006A0A50
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_DungeonRecoverProcess(this.opl_p0);
			int num2 = 500;
			bool flag = num >= num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F7C7 RID: 63431
		private int opl_p0;
	}
}
