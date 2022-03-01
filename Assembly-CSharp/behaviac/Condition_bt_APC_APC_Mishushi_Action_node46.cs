using System;

namespace behaviac
{
	// Token: 0x02001DCD RID: 7629
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Mishushi_Action_node46 : Condition
	{
		// Token: 0x06012552 RID: 75090 RVA: 0x0055A377 File Offset: 0x00558777
		public Condition_bt_APC_APC_Mishushi_Action_node46()
		{
			this.opl_p0 = 9744;
		}

		// Token: 0x06012553 RID: 75091 RVA: 0x0055A38C File Offset: 0x0055878C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF47 RID: 48967
		private int opl_p0;
	}
}
