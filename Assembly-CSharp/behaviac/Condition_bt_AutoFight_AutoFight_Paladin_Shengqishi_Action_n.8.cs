using System;

namespace behaviac
{
	// Token: 0x0200281C RID: 10268
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node62 : Condition
	{
		// Token: 0x06013976 RID: 80246 RVA: 0x005D88F3 File Offset: 0x005D6CF3
		public Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node62()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x06013977 RID: 80247 RVA: 0x005D8908 File Offset: 0x005D6D08
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D3D3 RID: 54227
		private float opl_p0;
	}
}
