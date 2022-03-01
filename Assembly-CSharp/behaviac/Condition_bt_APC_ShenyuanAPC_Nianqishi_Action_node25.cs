using System;

namespace behaviac
{
	// Token: 0x02001EC0 RID: 7872
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Nianqishi_Action_node25 : Condition
	{
		// Token: 0x06012728 RID: 75560 RVA: 0x00565200 File Offset: 0x00563600
		public Condition_bt_APC_ShenyuanAPC_Nianqishi_Action_node25()
		{
			this.opl_p0 = 9706;
		}

		// Token: 0x06012729 RID: 75561 RVA: 0x00565214 File Offset: 0x00563614
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C118 RID: 49432
		private int opl_p0;
	}
}
