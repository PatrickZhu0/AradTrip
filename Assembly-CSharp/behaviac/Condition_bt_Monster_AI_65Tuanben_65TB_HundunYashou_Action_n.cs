using System;

namespace behaviac
{
	// Token: 0x02002B7F RID: 11135
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Action_node11 : Condition
	{
		// Token: 0x0601400A RID: 81930 RVA: 0x00601C3D File Offset: 0x0060003D
		public Condition_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Action_node11()
		{
			this.opl_p0 = 20771;
		}

		// Token: 0x0601400B RID: 81931 RVA: 0x00601C50 File Offset: 0x00600050
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_HaveSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DA0A RID: 55818
		private int opl_p0;
	}
}
