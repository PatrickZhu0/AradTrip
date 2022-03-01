using System;

namespace behaviac
{
	// Token: 0x02002DFD RID: 11773
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node3 : Condition
	{
		// Token: 0x060144D7 RID: 83159 RVA: 0x006193CE File Offset: 0x006177CE
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node3()
		{
			this.opl_p0 = 0;
		}

		// Token: 0x060144D8 RID: 83160 RVA: 0x006193E0 File Offset: 0x006177E0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 1;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DE87 RID: 56967
		private int opl_p0;
	}
}
