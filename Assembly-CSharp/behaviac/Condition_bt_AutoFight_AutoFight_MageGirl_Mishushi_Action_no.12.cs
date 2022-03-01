using System;

namespace behaviac
{
	// Token: 0x020026BE RID: 9918
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node55 : Condition
	{
		// Token: 0x060136BF RID: 79551 RVA: 0x005C8C4D File Offset: 0x005C704D
		public Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node55()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x060136C0 RID: 79552 RVA: 0x005C8C60 File Offset: 0x005C7060
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D117 RID: 53527
		private float opl_p0;
	}
}
