using System;

namespace behaviac
{
	// Token: 0x02001DC9 RID: 7625
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Mishushi_Action_node90 : Condition
	{
		// Token: 0x0601254A RID: 75082 RVA: 0x0055A1C3 File Offset: 0x005585C3
		public Condition_bt_APC_APC_Mishushi_Action_node90()
		{
			this.opl_p0 = 9741;
		}

		// Token: 0x0601254B RID: 75083 RVA: 0x0055A1D8 File Offset: 0x005585D8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF3F RID: 48959
		private int opl_p0;
	}
}
