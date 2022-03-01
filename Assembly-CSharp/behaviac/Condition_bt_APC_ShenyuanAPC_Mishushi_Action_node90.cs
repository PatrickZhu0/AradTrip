using System;

namespace behaviac
{
	// Token: 0x02001E92 RID: 7826
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Mishushi_Action_node90 : Condition
	{
		// Token: 0x060126CE RID: 75470 RVA: 0x005636BB File Offset: 0x00561ABB
		public Condition_bt_APC_ShenyuanAPC_Mishushi_Action_node90()
		{
			this.opl_p0 = 9741;
		}

		// Token: 0x060126CF RID: 75471 RVA: 0x005636D0 File Offset: 0x00561AD0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C0BC RID: 49340
		private int opl_p0;
	}
}
