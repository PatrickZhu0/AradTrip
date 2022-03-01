using System;

namespace behaviac
{
	// Token: 0x02001D16 RID: 7446
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Guiqi2_Action_node73 : Condition
	{
		// Token: 0x060123EF RID: 74735 RVA: 0x00551C68 File Offset: 0x00550068
		public Condition_bt_APC_APC_Guiqi2_Action_node73()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x060123F0 RID: 74736 RVA: 0x00551C7C File Offset: 0x0055007C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BDE2 RID: 48610
		private float opl_p0;
	}
}
