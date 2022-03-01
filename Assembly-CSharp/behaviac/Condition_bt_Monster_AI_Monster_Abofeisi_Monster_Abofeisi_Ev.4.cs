using System;

namespace behaviac
{
	// Token: 0x020035DD RID: 13789
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Abofeisi_Monster_Abofeisi_Event_Abofeisi_node8 : Condition
	{
		// Token: 0x060153E3 RID: 87011 RVA: 0x0066743B File Offset: 0x0066583B
		public Condition_bt_Monster_AI_Monster_Abofeisi_Monster_Abofeisi_Event_Abofeisi_node8()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x060153E4 RID: 87012 RVA: 0x00667450 File Offset: 0x00665850
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EDA5 RID: 60837
		private float opl_p0;
	}
}
