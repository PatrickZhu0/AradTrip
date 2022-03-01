using System;

namespace behaviac
{
	// Token: 0x020026EF RID: 9967
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node12 : Condition
	{
		// Token: 0x06013721 RID: 79649 RVA: 0x005CA0F5 File Offset: 0x005C84F5
		public Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node12()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x06013722 RID: 79650 RVA: 0x005CA108 File Offset: 0x005C8508
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D179 RID: 53625
		private float opl_p0;
	}
}
