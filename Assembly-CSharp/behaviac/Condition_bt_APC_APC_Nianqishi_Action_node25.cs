using System;

namespace behaviac
{
	// Token: 0x02001DED RID: 7661
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Nianqishi_Action_node25 : Condition
	{
		// Token: 0x06012590 RID: 75152 RVA: 0x0055B7E4 File Offset: 0x00559BE4
		public Condition_bt_APC_APC_Nianqishi_Action_node25()
		{
			this.opl_p0 = 9706;
		}

		// Token: 0x06012591 RID: 75153 RVA: 0x0055B7F8 File Offset: 0x00559BF8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF86 RID: 49030
		private int opl_p0;
	}
}
