using System;

namespace behaviac
{
	// Token: 0x020039FC RID: 14844
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_EVENT_node88 : Condition
	{
		// Token: 0x06015BC6 RID: 89030 RVA: 0x00690C1B File Offset: 0x0068F01B
		public Condition_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_EVENT_node88()
		{
			this.opl_p0 = 0;
		}

		// Token: 0x06015BC7 RID: 89031 RVA: 0x00690C2C File Offset: 0x0068F02C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetTimerById(this.opl_p0);
			int num2 = 3000;
			bool flag = num >= num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F4F7 RID: 62711
		private int opl_p0;
	}
}
