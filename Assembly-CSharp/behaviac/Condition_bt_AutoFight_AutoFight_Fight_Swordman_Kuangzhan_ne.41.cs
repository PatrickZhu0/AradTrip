using System;

namespace behaviac
{
	// Token: 0x020023C8 RID: 9160
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node18 : Condition
	{
		// Token: 0x060130F6 RID: 78070 RVA: 0x005A5686 File Offset: 0x005A3A86
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node18()
		{
			this.opl_p0 = 0.01f;
		}

		// Token: 0x060130F7 RID: 78071 RVA: 0x005A569C File Offset: 0x005A3A9C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CB28 RID: 52008
		private float opl_p0;
	}
}
