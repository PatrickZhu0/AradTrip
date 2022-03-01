using System;

namespace behaviac
{
	// Token: 0x02003021 RID: 12321
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_3_0luoleikainuo_DestinationSelect_node33 : Condition
	{
		// Token: 0x0601490B RID: 84235 RVA: 0x006309A3 File Offset: 0x0062EDA3
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_3_0luoleikainuo_DestinationSelect_node33()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x0601490C RID: 84236 RVA: 0x006309B8 File Offset: 0x0062EDB8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E269 RID: 57961
		private float opl_p0;
	}
}
