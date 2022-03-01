using System;

namespace behaviac
{
	// Token: 0x02003036 RID: 12342
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_4_0dumaowang_DestinationSelect_node25 : Condition
	{
		// Token: 0x06014934 RID: 84276 RVA: 0x006318C3 File Offset: 0x0062FCC3
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_4_0dumaowang_DestinationSelect_node25()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x06014935 RID: 84277 RVA: 0x006318D8 File Offset: 0x0062FCD8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E292 RID: 58002
		private float opl_p0;
	}
}
