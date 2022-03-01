using System;

namespace behaviac
{
	// Token: 0x02002B95 RID: 11157
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Action_node17 : Condition
	{
		// Token: 0x06014036 RID: 81974 RVA: 0x00602479 File Offset: 0x00600879
		public Condition_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Action_node17()
		{
			this.opl_p0 = 20759;
		}

		// Token: 0x06014037 RID: 81975 RVA: 0x0060248C File Offset: 0x0060088C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DA2C RID: 55852
		private int opl_p0;
	}
}
