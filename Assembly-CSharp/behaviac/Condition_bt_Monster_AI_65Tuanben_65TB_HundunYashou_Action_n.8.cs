using System;

namespace behaviac
{
	// Token: 0x02002B8D RID: 11149
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Action_node4 : Condition
	{
		// Token: 0x06014026 RID: 81958 RVA: 0x00602179 File Offset: 0x00600579
		public Condition_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Action_node4()
		{
			this.opl_p0 = 20765;
		}

		// Token: 0x06014027 RID: 81959 RVA: 0x0060218C File Offset: 0x0060058C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DA1E RID: 55838
		private int opl_p0;
	}
}
