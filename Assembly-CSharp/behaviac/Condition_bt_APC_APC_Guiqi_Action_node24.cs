using System;

namespace behaviac
{
	// Token: 0x02001D3C RID: 7484
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Guiqi_Action_node24 : Condition
	{
		// Token: 0x0601243A RID: 74810 RVA: 0x00553ACF File Offset: 0x00551ECF
		public Condition_bt_APC_APC_Guiqi_Action_node24()
		{
			this.opl_p0 = 7090;
		}

		// Token: 0x0601243B RID: 74811 RVA: 0x00553AE4 File Offset: 0x00551EE4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE2D RID: 48685
		private int opl_p0;
	}
}
