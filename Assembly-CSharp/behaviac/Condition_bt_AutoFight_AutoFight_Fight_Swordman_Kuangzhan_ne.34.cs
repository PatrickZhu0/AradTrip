using System;

namespace behaviac
{
	// Token: 0x020023BE RID: 9150
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node25 : Condition
	{
		// Token: 0x060130E2 RID: 78050 RVA: 0x005A522D File Offset: 0x005A362D
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node25()
		{
			this.opl_p0 = 1510;
		}

		// Token: 0x060130E3 RID: 78051 RVA: 0x005A5240 File Offset: 0x005A3640
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CB15 RID: 51989
		private int opl_p0;
	}
}
