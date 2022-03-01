using System;

namespace behaviac
{
	// Token: 0x020023D4 RID: 9172
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node6 : Condition
	{
		// Token: 0x0601310D RID: 78093 RVA: 0x005A6ECF File Offset: 0x005A52CF
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node6()
		{
			this.opl_p0 = 1515;
		}

		// Token: 0x0601310E RID: 78094 RVA: 0x005A6EE4 File Offset: 0x005A52E4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CB3D RID: 52029
		private int opl_p0;
	}
}
