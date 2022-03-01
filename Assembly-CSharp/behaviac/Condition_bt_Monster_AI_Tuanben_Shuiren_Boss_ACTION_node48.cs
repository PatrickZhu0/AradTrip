using System;

namespace behaviac
{
	// Token: 0x02003B6D RID: 15213
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node48 : Condition
	{
		// Token: 0x06015E8F RID: 89743 RVA: 0x0069E1D2 File Offset: 0x0069C5D2
		public Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node48()
		{
			this.opl_p0 = 0.9f;
		}

		// Token: 0x06015E90 RID: 89744 RVA: 0x0069E1E8 File Offset: 0x0069C5E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F756 RID: 63318
		private float opl_p0;
	}
}
