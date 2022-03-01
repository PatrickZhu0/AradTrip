using System;

namespace behaviac
{
	// Token: 0x0200362E RID: 13870
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_node19 : Condition
	{
		// Token: 0x06015480 RID: 87168 RVA: 0x0066A623 File Offset: 0x00668A23
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_node19()
		{
			this.opl_p0 = 5426;
		}

		// Token: 0x06015481 RID: 87169 RVA: 0x0066A638 File Offset: 0x00668A38
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE3A RID: 60986
		private int opl_p0;
	}
}
