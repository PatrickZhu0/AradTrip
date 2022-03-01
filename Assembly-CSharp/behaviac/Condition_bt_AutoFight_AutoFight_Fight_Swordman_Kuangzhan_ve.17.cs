using System;

namespace behaviac
{
	// Token: 0x02002426 RID: 9254
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node74 : Condition
	{
		// Token: 0x060131A4 RID: 78244 RVA: 0x005AA234 File Offset: 0x005A8634
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node74()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x060131A5 RID: 78245 RVA: 0x005AA248 File Offset: 0x005A8648
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CBCD RID: 52173
		private float opl_p0;
	}
}
