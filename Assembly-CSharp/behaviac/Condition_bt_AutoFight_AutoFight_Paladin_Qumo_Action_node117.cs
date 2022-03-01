using System;

namespace behaviac
{
	// Token: 0x020027D8 RID: 10200
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node117 : Condition
	{
		// Token: 0x060138EF RID: 80111 RVA: 0x005D5015 File Offset: 0x005D3415
		public Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node117()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x060138F0 RID: 80112 RVA: 0x005D5028 File Offset: 0x005D3428
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D34F RID: 54095
		private float opl_p0;
	}
}
