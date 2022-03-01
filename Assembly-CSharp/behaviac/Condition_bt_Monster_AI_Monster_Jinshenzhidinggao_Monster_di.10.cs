using System;

namespace behaviac
{
	// Token: 0x02003694 RID: 13972
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_DestinationSelect_node7 : Condition
	{
		// Token: 0x06015545 RID: 87365 RVA: 0x0066F1DD File Offset: 0x0066D5DD
		public Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_DestinationSelect_node7()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x06015546 RID: 87366 RVA: 0x0066F1F0 File Offset: 0x0066D5F0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EF0A RID: 61194
		private float opl_p0;
	}
}
