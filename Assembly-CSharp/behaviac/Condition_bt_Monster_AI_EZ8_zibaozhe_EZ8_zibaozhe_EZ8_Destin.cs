using System;

namespace behaviac
{
	// Token: 0x0200329F RID: 12959
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_EZ8_zibaozhe_EZ8_zibaozhe_EZ8_DestinationSelect_node4 : Condition
	{
		// Token: 0x06014DB5 RID: 85429 RVA: 0x0064862C File Offset: 0x00646A2C
		public Condition_bt_Monster_AI_EZ8_zibaozhe_EZ8_zibaozhe_EZ8_DestinationSelect_node4()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x06014DB6 RID: 85430 RVA: 0x00648640 File Offset: 0x00646A40
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E6AA RID: 59050
		private float opl_p0;
	}
}
