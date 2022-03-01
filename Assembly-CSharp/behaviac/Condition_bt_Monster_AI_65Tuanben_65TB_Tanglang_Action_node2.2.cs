using System;

namespace behaviac
{
	// Token: 0x02002C8A RID: 11402
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Action_node2 : Condition
	{
		// Token: 0x0601420B RID: 82443 RVA: 0x0060B949 File Offset: 0x00609D49
		public Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Action_node2()
		{
			this.opl_p0 = 20750;
		}

		// Token: 0x0601420C RID: 82444 RVA: 0x0060B95C File Offset: 0x00609D5C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DBCA RID: 56266
		private int opl_p0;
	}
}
