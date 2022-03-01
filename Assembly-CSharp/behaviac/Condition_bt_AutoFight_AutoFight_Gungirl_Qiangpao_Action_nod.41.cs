using System;

namespace behaviac
{
	// Token: 0x02002549 RID: 9545
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node81 : Condition
	{
		// Token: 0x060133DB RID: 78811 RVA: 0x005B72A9 File Offset: 0x005B56A9
		public Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node81()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x060133DC RID: 78812 RVA: 0x005B72BC File Offset: 0x005B56BC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CE03 RID: 52739
		private float opl_p0;
	}
}
