using System;

namespace behaviac
{
	// Token: 0x02002703 RID: 9987
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node9 : Condition
	{
		// Token: 0x06013748 RID: 79688 RVA: 0x005CC0D5 File Offset: 0x005CA4D5
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node9()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06013749 RID: 79689 RVA: 0x005CC0E8 File Offset: 0x005CA4E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D1A0 RID: 53664
		private float opl_p0;
	}
}
