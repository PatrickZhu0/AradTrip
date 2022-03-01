using System;

namespace behaviac
{
	// Token: 0x020021FF RID: 8703
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_normal_Move_node2 : Condition
	{
		// Token: 0x06012D89 RID: 77193 RVA: 0x0058C831 File Offset: 0x0058AC31
		public Condition_bt_AutoFight_AutoFight_Fight_normal_Move_node2()
		{
			this.opl_p0 = 0;
		}

		// Token: 0x06012D8A RID: 77194 RVA: 0x0058C840 File Offset: 0x0058AC40
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C777 RID: 51063
		private int opl_p0;
	}
}
