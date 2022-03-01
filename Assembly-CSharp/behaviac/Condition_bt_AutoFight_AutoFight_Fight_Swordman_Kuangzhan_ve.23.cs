using System;

namespace behaviac
{
	// Token: 0x0200242E RID: 9262
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node63 : Condition
	{
		// Token: 0x060131B4 RID: 78260 RVA: 0x005AA5DE File Offset: 0x005A89DE
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node63()
		{
			this.opl_p0 = 0.72f;
		}

		// Token: 0x060131B5 RID: 78261 RVA: 0x005AA5F4 File Offset: 0x005A89F4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CBDC RID: 52188
		private float opl_p0;
	}
}
