using System;

namespace behaviac
{
	// Token: 0x02002C85 RID: 11397
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Action_node26 : Condition
	{
		// Token: 0x06014201 RID: 82433 RVA: 0x0060B7A8 File Offset: 0x00609BA8
		public Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Action_node26()
		{
			this.opl_p0 = 20757;
		}

		// Token: 0x06014202 RID: 82434 RVA: 0x0060B7BC File Offset: 0x00609BBC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DBC3 RID: 56259
		private int opl_p0;
	}
}
