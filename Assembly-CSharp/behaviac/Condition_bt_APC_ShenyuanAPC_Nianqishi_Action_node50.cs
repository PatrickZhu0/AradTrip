using System;

namespace behaviac
{
	// Token: 0x02001EB0 RID: 7856
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Nianqishi_Action_node50 : Condition
	{
		// Token: 0x06012708 RID: 75528 RVA: 0x00564B0B File Offset: 0x00562F0B
		public Condition_bt_APC_ShenyuanAPC_Nianqishi_Action_node50()
		{
			this.opl_p0 = 9701;
		}

		// Token: 0x06012709 RID: 75529 RVA: 0x00564B20 File Offset: 0x00562F20
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C0F6 RID: 49398
		private int opl_p0;
	}
}
