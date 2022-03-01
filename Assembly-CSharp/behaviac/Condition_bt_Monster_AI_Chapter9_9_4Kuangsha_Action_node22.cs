using System;

namespace behaviac
{
	// Token: 0x02003182 RID: 12674
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_4Kuangsha_Action_node22 : Condition
	{
		// Token: 0x06014B9B RID: 84891 RVA: 0x0063D82F File Offset: 0x0063BC2F
		public Condition_bt_Monster_AI_Chapter9_9_4Kuangsha_Action_node22()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06014B9C RID: 84892 RVA: 0x0063D844 File Offset: 0x0063BC44
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E507 RID: 58631
		private float opl_p0;
	}
}
