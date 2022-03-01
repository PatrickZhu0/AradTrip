using System;

namespace behaviac
{
	// Token: 0x020034A1 RID: 13473
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Kongbu_Action_node46 : Condition
	{
		// Token: 0x0601518A RID: 86410 RVA: 0x0065B709 File Offset: 0x00659B09
		public Condition_bt_Monster_AI_Heisedadi_Kongbu_Action_node46()
		{
			this.opl_p0 = 6205;
		}

		// Token: 0x0601518B RID: 86411 RVA: 0x0065B71C File Offset: 0x00659B1C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EA8C RID: 60044
		private int opl_p0;
	}
}
