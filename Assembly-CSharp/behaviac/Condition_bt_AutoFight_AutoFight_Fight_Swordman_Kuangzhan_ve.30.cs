using System;

namespace behaviac
{
	// Token: 0x02002436 RID: 9270
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node57 : Condition
	{
		// Token: 0x060131C4 RID: 78276 RVA: 0x005AA913 File Offset: 0x005A8D13
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node57()
		{
			this.opl_p0 = 1511;
		}

		// Token: 0x060131C5 RID: 78277 RVA: 0x005AA928 File Offset: 0x005A8D28
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CBEF RID: 52207
		private int opl_p0;
	}
}
