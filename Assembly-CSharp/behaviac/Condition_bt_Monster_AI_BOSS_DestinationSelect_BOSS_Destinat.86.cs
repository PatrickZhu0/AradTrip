using System;

namespace behaviac
{
	// Token: 0x02003033 RID: 12339
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_4_0dumaowang_DestinationSelect_node21 : Condition
	{
		// Token: 0x0601492E RID: 84270 RVA: 0x006317D7 File Offset: 0x0062FBD7
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_4_0dumaowang_DestinationSelect_node21()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x0601492F RID: 84271 RVA: 0x006317EC File Offset: 0x0062FBEC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E28C RID: 57996
		private float opl_p0;
	}
}
