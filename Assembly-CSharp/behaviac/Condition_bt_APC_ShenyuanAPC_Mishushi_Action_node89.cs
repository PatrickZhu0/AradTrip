using System;

namespace behaviac
{
	// Token: 0x02001E91 RID: 7825
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Mishushi_Action_node89 : Condition
	{
		// Token: 0x060126CC RID: 75468 RVA: 0x00563675 File Offset: 0x00561A75
		public Condition_bt_APC_ShenyuanAPC_Mishushi_Action_node89()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x060126CD RID: 75469 RVA: 0x00563688 File Offset: 0x00561A88
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C0BB RID: 49339
		private float opl_p0;
	}
}
