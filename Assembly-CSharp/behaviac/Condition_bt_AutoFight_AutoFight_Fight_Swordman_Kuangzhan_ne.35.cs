using System;

namespace behaviac
{
	// Token: 0x020023C0 RID: 9152
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node50 : Condition
	{
		// Token: 0x060130E6 RID: 78054 RVA: 0x005A531E File Offset: 0x005A371E
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node50()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x060130E7 RID: 78055 RVA: 0x005A5334 File Offset: 0x005A3734
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CB18 RID: 51992
		private float opl_p0;
	}
}
