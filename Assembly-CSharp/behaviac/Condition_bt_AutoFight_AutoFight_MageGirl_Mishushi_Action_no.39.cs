using System;

namespace behaviac
{
	// Token: 0x020026E3 RID: 9955
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node28 : Condition
	{
		// Token: 0x06013709 RID: 79625 RVA: 0x005C9BD9 File Offset: 0x005C7FD9
		public Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node28()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x0601370A RID: 79626 RVA: 0x005C9BEC File Offset: 0x005C7FEC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D161 RID: 53601
		private float opl_p0;
	}
}
