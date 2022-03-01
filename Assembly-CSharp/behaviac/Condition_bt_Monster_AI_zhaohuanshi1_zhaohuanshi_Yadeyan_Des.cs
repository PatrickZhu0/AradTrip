using System;

namespace behaviac
{
	// Token: 0x020040A0 RID: 16544
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Yadeyan_DestinationSelect_node4 : Condition
	{
		// Token: 0x0601689A RID: 92314 RVA: 0x006D31A0 File Offset: 0x006D15A0
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Yadeyan_DestinationSelect_node4()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x0601689B RID: 92315 RVA: 0x006D31B4 File Offset: 0x006D15B4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x040100E2 RID: 65762
		private float opl_p0;
	}
}
