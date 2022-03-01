using System;

namespace behaviac
{
	// Token: 0x02001E96 RID: 7830
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Mishushi_Action_node66 : Condition
	{
		// Token: 0x060126D6 RID: 75478 RVA: 0x0056386F File Offset: 0x00561C6F
		public Condition_bt_APC_ShenyuanAPC_Mishushi_Action_node66()
		{
			this.opl_p0 = 9742;
		}

		// Token: 0x060126D7 RID: 75479 RVA: 0x00563884 File Offset: 0x00561C84
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C0C4 RID: 49348
		private int opl_p0;
	}
}
