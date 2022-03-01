using System;

namespace behaviac
{
	// Token: 0x02003B69 RID: 15209
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node44 : Condition
	{
		// Token: 0x06015E87 RID: 89735 RVA: 0x0069E01A File Offset: 0x0069C41A
		public Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node44()
		{
			this.opl_p0 = 0.7f;
		}

		// Token: 0x06015E88 RID: 89736 RVA: 0x0069E030 File Offset: 0x0069C430
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F74E RID: 63310
		private float opl_p0;
	}
}
