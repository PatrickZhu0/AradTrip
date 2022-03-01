using System;

namespace behaviac
{
	// Token: 0x020029CF RID: 10703
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node62 : Condition
	{
		// Token: 0x06013CD2 RID: 81106 RVA: 0x005EBB6A File Offset: 0x005E9F6A
		public Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node62()
		{
			this.opl_p0 = 0.56f;
		}

		// Token: 0x06013CD3 RID: 81107 RVA: 0x005EBB80 File Offset: 0x005E9F80
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D741 RID: 55105
		private float opl_p0;
	}
}
