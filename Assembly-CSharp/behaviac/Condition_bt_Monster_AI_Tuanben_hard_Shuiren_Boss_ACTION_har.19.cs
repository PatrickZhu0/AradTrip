using System;

namespace behaviac
{
	// Token: 0x02003D5C RID: 15708
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node20 : Condition
	{
		// Token: 0x0601624E RID: 90702 RVA: 0x006B1163 File Offset: 0x006AF563
		public Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node20()
		{
			this.opl_p0 = 2;
		}

		// Token: 0x0601624F RID: 90703 RVA: 0x006B1174 File Offset: 0x006AF574
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 7;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FAAA RID: 64170
		private int opl_p0;
	}
}
