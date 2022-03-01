using System;

namespace behaviac
{
	// Token: 0x020023C4 RID: 9156
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node12 : Condition
	{
		// Token: 0x060130EE RID: 78062 RVA: 0x005A54D2 File Offset: 0x005A38D2
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node12()
		{
			this.opl_p0 = 0.01f;
		}

		// Token: 0x060130EF RID: 78063 RVA: 0x005A54E8 File Offset: 0x005A38E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CB20 RID: 52000
		private float opl_p0;
	}
}
