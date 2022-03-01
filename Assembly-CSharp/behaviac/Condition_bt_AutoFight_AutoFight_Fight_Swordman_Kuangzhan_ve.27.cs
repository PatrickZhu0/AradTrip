using System;

namespace behaviac
{
	// Token: 0x02002433 RID: 9267
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node54 : Condition
	{
		// Token: 0x060131BE RID: 78270 RVA: 0x005AA7F2 File Offset: 0x005A8BF2
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node54()
		{
			this.opl_p0 = 0.45f;
		}

		// Token: 0x060131BF RID: 78271 RVA: 0x005AA808 File Offset: 0x005A8C08
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CBE7 RID: 52199
		private float opl_p0;
	}
}
