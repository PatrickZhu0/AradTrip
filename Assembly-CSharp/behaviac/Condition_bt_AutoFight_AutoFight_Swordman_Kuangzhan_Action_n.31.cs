using System;

namespace behaviac
{
	// Token: 0x0200296D RID: 10605
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node48 : Condition
	{
		// Token: 0x06013C0F RID: 80911 RVA: 0x005E7CDB File Offset: 0x005E60DB
		public Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node48()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x06013C10 RID: 80912 RVA: 0x005E7CF0 File Offset: 0x005E60F0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D676 RID: 54902
		private float opl_p0;
	}
}
