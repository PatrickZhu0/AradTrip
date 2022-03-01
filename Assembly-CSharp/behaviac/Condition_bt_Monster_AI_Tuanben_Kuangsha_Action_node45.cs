using System;

namespace behaviac
{
	// Token: 0x02003ADD RID: 15069
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Kuangsha_Action_node45 : Condition
	{
		// Token: 0x06015D79 RID: 89465 RVA: 0x00699023 File Offset: 0x00697423
		public Condition_bt_Monster_AI_Tuanben_Kuangsha_Action_node45()
		{
			this.opl_p0 = 0.9f;
		}

		// Token: 0x06015D7A RID: 89466 RVA: 0x00699038 File Offset: 0x00697438
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F689 RID: 63113
		private float opl_p0;
	}
}
