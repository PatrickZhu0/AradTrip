using System;

namespace behaviac
{
	// Token: 0x02003AD3 RID: 15059
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Kuangsha_Action_node22 : Condition
	{
		// Token: 0x06015D65 RID: 89445 RVA: 0x00698BFB File Offset: 0x00696FFB
		public Condition_bt_Monster_AI_Tuanben_Kuangsha_Action_node22()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06015D66 RID: 89446 RVA: 0x00698C10 File Offset: 0x00697010
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F673 RID: 63091
		private float opl_p0;
	}
}
