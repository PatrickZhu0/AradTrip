using System;

namespace behaviac
{
	// Token: 0x0200248F RID: 9359
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node19 : Condition
	{
		// Token: 0x0601326A RID: 78442 RVA: 0x005AF2B1 File Offset: 0x005AD6B1
		public Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node19()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x0601326B RID: 78443 RVA: 0x005AF2C4 File Offset: 0x005AD6C4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC84 RID: 52356
		private float opl_p0;
	}
}
