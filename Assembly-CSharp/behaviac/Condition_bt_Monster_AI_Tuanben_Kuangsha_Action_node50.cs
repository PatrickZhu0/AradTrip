using System;

namespace behaviac
{
	// Token: 0x02003ACE RID: 15054
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Kuangsha_Action_node50 : Condition
	{
		// Token: 0x06015D5B RID: 89435 RVA: 0x006989E7 File Offset: 0x00696DE7
		public Condition_bt_Monster_AI_Tuanben_Kuangsha_Action_node50()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06015D5C RID: 89436 RVA: 0x006989FC File Offset: 0x00696DFC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F668 RID: 63080
		private float opl_p0;
	}
}
