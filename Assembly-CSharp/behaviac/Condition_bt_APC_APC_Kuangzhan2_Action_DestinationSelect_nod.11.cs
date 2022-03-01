using System;

namespace behaviac
{
	// Token: 0x02001DA0 RID: 7584
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Kuangzhan2_Action_DestinationSelect_node27 : Condition
	{
		// Token: 0x060124FA RID: 75002 RVA: 0x005581D3 File Offset: 0x005565D3
		public Condition_bt_APC_APC_Kuangzhan2_Action_DestinationSelect_node27()
		{
			this.opl_p0 = 9702;
		}

		// Token: 0x060124FB RID: 75003 RVA: 0x005581E8 File Offset: 0x005565E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BEE5 RID: 48869
		private int opl_p0;
	}
}
