using System;

namespace behaviac
{
	// Token: 0x02001D36 RID: 7478
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Guiqi_Action_node12 : Condition
	{
		// Token: 0x0601242E RID: 74798 RVA: 0x00553855 File Offset: 0x00551C55
		public Condition_bt_APC_APC_Guiqi_Action_node12()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x0601242F RID: 74799 RVA: 0x00553868 File Offset: 0x00551C68
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE20 RID: 48672
		private float opl_p0;
	}
}
