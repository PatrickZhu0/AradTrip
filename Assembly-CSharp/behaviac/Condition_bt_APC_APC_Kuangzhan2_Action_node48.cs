using System;

namespace behaviac
{
	// Token: 0x02001D7F RID: 7551
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Kuangzhan2_Action_node48 : Condition
	{
		// Token: 0x060124B9 RID: 74937 RVA: 0x00556B41 File Offset: 0x00554F41
		public Condition_bt_APC_APC_Kuangzhan2_Action_node48()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x060124BA RID: 74938 RVA: 0x00556B54 File Offset: 0x00554F54
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BEA4 RID: 48804
		private float opl_p0;
	}
}
