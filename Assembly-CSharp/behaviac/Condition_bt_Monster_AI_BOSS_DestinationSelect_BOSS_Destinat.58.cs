using System;

namespace behaviac
{
	// Token: 0x02003006 RID: 12294
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_2_0shixuemaoyao_DestinationSelect_node29 : Condition
	{
		// Token: 0x060148D6 RID: 84182 RVA: 0x0062F993 File Offset: 0x0062DD93
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_2_0shixuemaoyao_DestinationSelect_node29()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x060148D7 RID: 84183 RVA: 0x0062F9A8 File Offset: 0x0062DDA8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E234 RID: 57908
		private float opl_p0;
	}
}
