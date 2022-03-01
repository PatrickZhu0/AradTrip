using System;

namespace behaviac
{
	// Token: 0x02002EBD RID: 11965
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node57 : Condition
	{
		// Token: 0x06014654 RID: 83540 RVA: 0x0062230E File Offset: 0x0062070E
		public Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node57()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x06014655 RID: 83541 RVA: 0x00622324 File Offset: 0x00620724
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DFC5 RID: 57285
		private float opl_p0;
	}
}
