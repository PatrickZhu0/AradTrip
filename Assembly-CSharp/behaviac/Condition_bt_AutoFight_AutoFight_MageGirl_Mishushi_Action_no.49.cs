using System;

namespace behaviac
{
	// Token: 0x020026F0 RID: 9968
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node13 : Condition
	{
		// Token: 0x06013723 RID: 79651 RVA: 0x005CA13B File Offset: 0x005C853B
		public Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node13()
		{
			this.opl_p0 = 2009;
		}

		// Token: 0x06013724 RID: 79652 RVA: 0x005CA150 File Offset: 0x005C8550
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D17A RID: 53626
		private int opl_p0;
	}
}
