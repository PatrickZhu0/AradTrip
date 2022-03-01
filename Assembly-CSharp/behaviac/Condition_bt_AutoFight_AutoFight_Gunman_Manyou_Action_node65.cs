using System;

namespace behaviac
{
	// Token: 0x02002615 RID: 9749
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node65 : Condition
	{
		// Token: 0x06013570 RID: 79216 RVA: 0x005C0E19 File Offset: 0x005BF219
		public Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node65()
		{
			this.opl_p0 = 1008;
		}

		// Token: 0x06013571 RID: 79217 RVA: 0x005C0E2C File Offset: 0x005BF22C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CFBD RID: 53181
		private int opl_p0;
	}
}
