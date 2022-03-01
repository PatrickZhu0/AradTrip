using System;

namespace behaviac
{
	// Token: 0x02001DB8 RID: 7608
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Kuangzhan_Action_node12 : Condition
	{
		// Token: 0x06012529 RID: 75049 RVA: 0x00559663 File Offset: 0x00557A63
		public Condition_bt_APC_APC_Kuangzhan_Action_node12()
		{
			this.opl_p0 = 7107;
		}

		// Token: 0x0601252A RID: 75050 RVA: 0x00559678 File Offset: 0x00557A78
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF1C RID: 48924
		private int opl_p0;
	}
}
