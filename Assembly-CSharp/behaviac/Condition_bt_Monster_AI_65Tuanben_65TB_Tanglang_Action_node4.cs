using System;

namespace behaviac
{
	// Token: 0x02002C8E RID: 11406
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Action_node4 : Condition
	{
		// Token: 0x06014213 RID: 82451 RVA: 0x0060BAC9 File Offset: 0x00609EC9
		public Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Action_node4()
		{
			this.opl_p0 = 20751;
		}

		// Token: 0x06014214 RID: 82452 RVA: 0x0060BADC File Offset: 0x00609EDC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DBD1 RID: 56273
		private int opl_p0;
	}
}
