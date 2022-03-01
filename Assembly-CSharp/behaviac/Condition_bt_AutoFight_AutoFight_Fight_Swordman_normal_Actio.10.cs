using System;

namespace behaviac
{
	// Token: 0x02002447 RID: 9287
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_normal_Action_node42 : Condition
	{
		// Token: 0x060131E2 RID: 78306 RVA: 0x005ABDD7 File Offset: 0x005AA1D7
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_normal_Action_node42()
		{
			this.opl_p0 = 1514;
		}

		// Token: 0x060131E3 RID: 78307 RVA: 0x005ABDEC File Offset: 0x005AA1EC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC0A RID: 52234
		private int opl_p0;
	}
}
