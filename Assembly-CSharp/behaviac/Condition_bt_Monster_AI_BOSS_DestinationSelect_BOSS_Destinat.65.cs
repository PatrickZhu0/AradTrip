using System;

namespace behaviac
{
	// Token: 0x02003012 RID: 12306
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_3_0luoleikainuo_DestinationSelect_node13 : Condition
	{
		// Token: 0x060148ED RID: 84205 RVA: 0x00630507 File Offset: 0x0062E907
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_3_0luoleikainuo_DestinationSelect_node13()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x060148EE RID: 84206 RVA: 0x0063051C File Offset: 0x0062E91C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E24B RID: 57931
		private float opl_p0;
	}
}
