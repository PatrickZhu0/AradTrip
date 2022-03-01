using System;

namespace behaviac
{
	// Token: 0x02002B80 RID: 11136
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Action_node25 : Condition
	{
		// Token: 0x0601400C RID: 81932 RVA: 0x00601C83 File Offset: 0x00600083
		public Condition_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Action_node25()
		{
			this.opl_p0 = 20771;
		}

		// Token: 0x0601400D RID: 81933 RVA: 0x00601C98 File Offset: 0x00600098
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DA0B RID: 55819
		private int opl_p0;
	}
}
