using System;

namespace behaviac
{
	// Token: 0x020023BC RID: 9148
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node23 : Condition
	{
		// Token: 0x060130DE RID: 78046 RVA: 0x005A516B File Offset: 0x005A356B
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node23()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x060130DF RID: 78047 RVA: 0x005A5180 File Offset: 0x005A3580
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CB10 RID: 51984
		private float opl_p0;
	}
}
