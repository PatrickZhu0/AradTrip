using System;

namespace behaviac
{
	// Token: 0x02003697 RID: 13975
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_DestinationSelect_node2 : Condition
	{
		// Token: 0x0601554B RID: 87371 RVA: 0x0066F2C9 File Offset: 0x0066D6C9
		public Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_DestinationSelect_node2()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x0601554C RID: 87372 RVA: 0x0066F2DC File Offset: 0x0066D6DC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EF10 RID: 61200
		private float opl_p0;
	}
}
