using System;

namespace behaviac
{
	// Token: 0x020027AC RID: 10156
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Action_node38 : Condition
	{
		// Token: 0x06013898 RID: 80024 RVA: 0x005D3011 File Offset: 0x005D1411
		public Condition_bt_AutoFight_AutoFight_Paladin_Action_node38()
		{
			this.opl_p0 = 0.15f;
		}

		// Token: 0x06013899 RID: 80025 RVA: 0x005D3024 File Offset: 0x005D1424
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D2F9 RID: 54009
		private float opl_p0;
	}
}
