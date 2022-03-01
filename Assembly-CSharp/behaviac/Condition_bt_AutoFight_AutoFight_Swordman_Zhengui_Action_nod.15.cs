using System;

namespace behaviac
{
	// Token: 0x02002990 RID: 10640
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node117 : Condition
	{
		// Token: 0x06013C54 RID: 80980 RVA: 0x005E9F52 File Offset: 0x005E8352
		public Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node117()
		{
			this.opl_p0 = 0.65f;
		}

		// Token: 0x06013C55 RID: 80981 RVA: 0x005E9F68 File Offset: 0x005E8368
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D6BD RID: 54973
		private float opl_p0;
	}
}
