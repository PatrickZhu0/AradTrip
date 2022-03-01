using System;

namespace behaviac
{
	// Token: 0x02001EBD RID: 7869
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Nianqishi_Action_node5 : Condition
	{
		// Token: 0x06012722 RID: 75554 RVA: 0x0056508F File Offset: 0x0056348F
		public Condition_bt_APC_ShenyuanAPC_Nianqishi_Action_node5()
		{
			this.opl_p0 = 9704;
		}

		// Token: 0x06012723 RID: 75555 RVA: 0x005650A4 File Offset: 0x005634A4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C111 RID: 49425
		private int opl_p0;
	}
}
