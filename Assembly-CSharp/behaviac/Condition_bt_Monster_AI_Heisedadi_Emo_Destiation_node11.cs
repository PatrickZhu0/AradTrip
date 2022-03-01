using System;

namespace behaviac
{
	// Token: 0x02003402 RID: 13314
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Emo_Destiation_node11 : Condition
	{
		// Token: 0x06015056 RID: 86102 RVA: 0x00655405 File Offset: 0x00653805
		public Condition_bt_Monster_AI_Heisedadi_Emo_Destiation_node11()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x06015057 RID: 86103 RVA: 0x00655418 File Offset: 0x00653818
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E937 RID: 59703
		private float opl_p0;
	}
}
