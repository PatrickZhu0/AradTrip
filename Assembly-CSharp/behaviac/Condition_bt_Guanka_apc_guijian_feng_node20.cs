using System;

namespace behaviac
{
	// Token: 0x02002A4F RID: 10831
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_guijian_feng_node20 : Condition
	{
		// Token: 0x06013DC9 RID: 81353 RVA: 0x005F3803 File Offset: 0x005F1C03
		public Condition_bt_Guanka_apc_guijian_feng_node20()
		{
			this.opl_p0 = 1604;
		}

		// Token: 0x06013DCA RID: 81354 RVA: 0x005F3818 File Offset: 0x005F1C18
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D83D RID: 55357
		private int opl_p0;
	}
}
