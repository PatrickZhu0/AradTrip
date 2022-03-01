using System;

namespace behaviac
{
	// Token: 0x020023A0 RID: 9120
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node33 : Condition
	{
		// Token: 0x060130A6 RID: 77990 RVA: 0x005A2AF2 File Offset: 0x005A0EF2
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node33()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x060130A7 RID: 77991 RVA: 0x005A2B08 File Offset: 0x005A0F08
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CACA RID: 51914
		private float opl_p0;
	}
}
