using System;

namespace behaviac
{
	// Token: 0x02001E70 RID: 7792
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Kuangzhan2_Action_node3 : Condition
	{
		// Token: 0x0601268C RID: 75404 RVA: 0x00561BDB File Offset: 0x0055FFDB
		public Condition_bt_APC_ShenyuanAPC_Kuangzhan2_Action_node3()
		{
			this.opl_p0 = 9720;
		}

		// Token: 0x0601268D RID: 75405 RVA: 0x00561BF0 File Offset: 0x0055FFF0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C075 RID: 49269
		private int opl_p0;
	}
}
