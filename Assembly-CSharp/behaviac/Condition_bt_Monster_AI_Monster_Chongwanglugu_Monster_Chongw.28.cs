using System;

namespace behaviac
{
	// Token: 0x02003618 RID: 13848
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_DestinationSelect_node17 : Condition
	{
		// Token: 0x06015455 RID: 87125 RVA: 0x00669B87 File Offset: 0x00667F87
		public Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_DestinationSelect_node17()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06015456 RID: 87126 RVA: 0x00669B9C File Offset: 0x00667F9C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE0F RID: 60943
		private float opl_p0;
	}
}
