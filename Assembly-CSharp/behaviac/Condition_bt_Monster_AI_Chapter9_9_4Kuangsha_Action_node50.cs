using System;

namespace behaviac
{
	// Token: 0x0200317D RID: 12669
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_4Kuangsha_Action_node50 : Condition
	{
		// Token: 0x06014B91 RID: 84881 RVA: 0x0063D61B File Offset: 0x0063BA1B
		public Condition_bt_Monster_AI_Chapter9_9_4Kuangsha_Action_node50()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06014B92 RID: 84882 RVA: 0x0063D630 File Offset: 0x0063BA30
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E4FC RID: 58620
		private float opl_p0;
	}
}
