using System;

namespace behaviac
{
	// Token: 0x02001E14 RID: 7700
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Tiantangmanbuzhe_Action_node3 : Condition
	{
		// Token: 0x060125D9 RID: 75225 RVA: 0x0055D829 File Offset: 0x0055BC29
		public Condition_bt_APC_APC_Tiantangmanbuzhe_Action_node3()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x060125DA RID: 75226 RVA: 0x0055D83C File Offset: 0x0055BC3C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BFC3 RID: 49091
		private float opl_p0;
	}
}
