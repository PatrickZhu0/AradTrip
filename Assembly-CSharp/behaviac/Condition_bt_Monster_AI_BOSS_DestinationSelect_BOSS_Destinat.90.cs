using System;

namespace behaviac
{
	// Token: 0x02003039 RID: 12345
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_4_0dumaowang_DestinationSelect_node29 : Condition
	{
		// Token: 0x0601493A RID: 84282 RVA: 0x006319AF File Offset: 0x0062FDAF
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_4_0dumaowang_DestinationSelect_node29()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x0601493B RID: 84283 RVA: 0x006319C4 File Offset: 0x0062FDC4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E298 RID: 58008
		private float opl_p0;
	}
}
