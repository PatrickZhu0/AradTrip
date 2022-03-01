using System;

namespace behaviac
{
	// Token: 0x0200301B RID: 12315
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_3_0luoleikainuo_DestinationSelect_node25 : Condition
	{
		// Token: 0x060148FF RID: 84223 RVA: 0x006307CB File Offset: 0x0062EBCB
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_3_0luoleikainuo_DestinationSelect_node25()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x06014900 RID: 84224 RVA: 0x006307E0 File Offset: 0x0062EBE0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E25D RID: 57949
		private float opl_p0;
	}
}
