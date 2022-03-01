using System;

namespace behaviac
{
	// Token: 0x0200301E RID: 12318
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_3_0luoleikainuo_DestinationSelect_node29 : Condition
	{
		// Token: 0x06014905 RID: 84229 RVA: 0x006308B7 File Offset: 0x0062ECB7
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_3_0luoleikainuo_DestinationSelect_node29()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x06014906 RID: 84230 RVA: 0x006308CC File Offset: 0x0062ECCC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E263 RID: 57955
		private float opl_p0;
	}
}
