using System;

namespace behaviac
{
	// Token: 0x02003615 RID: 13845
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_DestinationSelect_node13 : Condition
	{
		// Token: 0x0601544F RID: 87119 RVA: 0x00669A9A File Offset: 0x00667E9A
		public Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_DestinationSelect_node13()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06015450 RID: 87120 RVA: 0x00669AB0 File Offset: 0x00667EB0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE09 RID: 60937
		private float opl_p0;
	}
}
