using System;

namespace behaviac
{
	// Token: 0x02003B71 RID: 15217
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node53 : Condition
	{
		// Token: 0x06015E97 RID: 89751 RVA: 0x0069E38A File Offset: 0x0069C78A
		public Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node53()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06015E98 RID: 89752 RVA: 0x0069E3A0 File Offset: 0x0069C7A0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F75E RID: 63326
		private float opl_p0;
	}
}
