using System;

namespace behaviac
{
	// Token: 0x02002A96 RID: 10902
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Mofashi_li_node14 : Condition
	{
		// Token: 0x06013E4E RID: 81486 RVA: 0x005F7573 File Offset: 0x005F5973
		public Condition_bt_Guanka_apc_Mofashi_li_node14()
		{
			this.opl_p0 = 2005;
		}

		// Token: 0x06013E4F RID: 81487 RVA: 0x005F7588 File Offset: 0x005F5988
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D8C3 RID: 55491
		private int opl_p0;
	}
}
