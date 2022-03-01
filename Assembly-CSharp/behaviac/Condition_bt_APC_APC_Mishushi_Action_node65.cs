using System;

namespace behaviac
{
	// Token: 0x02001DC4 RID: 7620
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Mishushi_Action_node65 : Condition
	{
		// Token: 0x06012540 RID: 75072 RVA: 0x00559FC9 File Offset: 0x005583C9
		public Condition_bt_APC_APC_Mishushi_Action_node65()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x06012541 RID: 75073 RVA: 0x00559FDC File Offset: 0x005583DC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF36 RID: 48950
		private float opl_p0;
	}
}
