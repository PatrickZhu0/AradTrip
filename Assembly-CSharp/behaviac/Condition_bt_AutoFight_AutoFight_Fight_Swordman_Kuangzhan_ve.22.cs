using System;

namespace behaviac
{
	// Token: 0x0200242C RID: 9260
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node40 : Condition
	{
		// Token: 0x060131B0 RID: 78256 RVA: 0x005AA4EB File Offset: 0x005A88EB
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node40()
		{
			this.opl_p0 = 1512;
		}

		// Token: 0x060131B1 RID: 78257 RVA: 0x005AA500 File Offset: 0x005A8900
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CBD9 RID: 52185
		private int opl_p0;
	}
}
