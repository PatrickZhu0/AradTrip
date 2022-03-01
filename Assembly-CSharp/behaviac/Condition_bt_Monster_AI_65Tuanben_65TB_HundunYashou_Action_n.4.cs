using System;

namespace behaviac
{
	// Token: 0x02002B83 RID: 11139
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Action_node28 : Condition
	{
		// Token: 0x06014012 RID: 81938 RVA: 0x00601DDA File Offset: 0x006001DA
		public Condition_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Action_node28()
		{
			this.opl_p0 = 20770;
		}

		// Token: 0x06014013 RID: 81939 RVA: 0x00601DF0 File Offset: 0x006001F0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DA11 RID: 55825
		private int opl_p0;
	}
}
