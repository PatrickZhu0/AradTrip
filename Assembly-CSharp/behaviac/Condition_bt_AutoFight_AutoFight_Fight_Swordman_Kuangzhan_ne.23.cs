using System;

namespace behaviac
{
	// Token: 0x020023B0 RID: 9136
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node70 : Condition
	{
		// Token: 0x060130C6 RID: 78022 RVA: 0x005A41B2 File Offset: 0x005A25B2
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node70()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x060130C7 RID: 78023 RVA: 0x005A41C8 File Offset: 0x005A25C8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CAF2 RID: 51954
		private float opl_p0;
	}
}
