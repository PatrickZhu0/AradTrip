using System;

namespace behaviac
{
	// Token: 0x020032A3 RID: 12963
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_EZ8_zibaozhe_EZ8_zibaozhe_EZ8_DestinationSelect_node8 : Condition
	{
		// Token: 0x06014DBD RID: 85437 RVA: 0x0064870D File Offset: 0x00646B0D
		public Condition_bt_Monster_AI_EZ8_zibaozhe_EZ8_zibaozhe_EZ8_DestinationSelect_node8()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x06014DBE RID: 85438 RVA: 0x00648720 File Offset: 0x00646B20
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E6AE RID: 59054
		private float opl_p0;
	}
}
