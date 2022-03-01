using System;

namespace behaviac
{
	// Token: 0x020032A1 RID: 12961
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_EZ8_zibaozhe_EZ8_zibaozhe_EZ8_DestinationSelect_node3 : Condition
	{
		// Token: 0x06014DB9 RID: 85433 RVA: 0x0064869D File Offset: 0x00646A9D
		public Condition_bt_Monster_AI_EZ8_zibaozhe_EZ8_zibaozhe_EZ8_DestinationSelect_node3()
		{
			this.opl_p0 = 0.7f;
		}

		// Token: 0x06014DBA RID: 85434 RVA: 0x006486B0 File Offset: 0x00646AB0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E6AC RID: 59052
		private float opl_p0;
	}
}
