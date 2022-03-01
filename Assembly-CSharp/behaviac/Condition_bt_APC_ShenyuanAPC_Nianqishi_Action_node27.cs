using System;

namespace behaviac
{
	// Token: 0x02001EB8 RID: 7864
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Nianqishi_Action_node27 : Condition
	{
		// Token: 0x06012718 RID: 75544 RVA: 0x00564E73 File Offset: 0x00563273
		public Condition_bt_APC_ShenyuanAPC_Nianqishi_Action_node27()
		{
			this.opl_p0 = 9702;
		}

		// Token: 0x06012719 RID: 75545 RVA: 0x00564E88 File Offset: 0x00563288
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C106 RID: 49414
		private int opl_p0;
	}
}
