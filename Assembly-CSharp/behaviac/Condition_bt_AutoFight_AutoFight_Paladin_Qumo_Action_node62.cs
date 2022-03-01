using System;

namespace behaviac
{
	// Token: 0x020027E4 RID: 10212
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node62 : Condition
	{
		// Token: 0x06013907 RID: 80135 RVA: 0x005D5531 File Offset: 0x005D3931
		public Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node62()
		{
			this.opl_p0 = 0.15f;
		}

		// Token: 0x06013908 RID: 80136 RVA: 0x005D5544 File Offset: 0x005D3944
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D367 RID: 54119
		private float opl_p0;
	}
}
