using System;

namespace behaviac
{
	// Token: 0x0200241C RID: 9244
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node26 : Condition
	{
		// Token: 0x06013192 RID: 78226 RVA: 0x005A9E54 File Offset: 0x005A8254
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node26()
		{
			this.opl_p0 = 0.75f;
		}

		// Token: 0x06013193 RID: 78227 RVA: 0x005A9E68 File Offset: 0x005A8268
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CBBD RID: 52157
		private float opl_p0;
	}
}
