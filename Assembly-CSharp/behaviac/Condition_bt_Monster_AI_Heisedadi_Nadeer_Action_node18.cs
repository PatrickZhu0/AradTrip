using System;

namespace behaviac
{
	// Token: 0x020034E0 RID: 13536
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Nadeer_Action_node18 : Condition
	{
		// Token: 0x06015205 RID: 86533 RVA: 0x0065DB89 File Offset: 0x0065BF89
		public Condition_bt_Monster_AI_Heisedadi_Nadeer_Action_node18()
		{
			this.opl_p0 = 0.7f;
		}

		// Token: 0x06015206 RID: 86534 RVA: 0x0065DB9C File Offset: 0x0065BF9C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EB1E RID: 60190
		private float opl_p0;
	}
}
