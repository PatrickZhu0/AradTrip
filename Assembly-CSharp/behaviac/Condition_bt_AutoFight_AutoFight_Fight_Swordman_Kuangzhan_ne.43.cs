using System;

namespace behaviac
{
	// Token: 0x020023CA RID: 9162
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node20 : Condition
	{
		// Token: 0x060130FA RID: 78074 RVA: 0x005A5749 File Offset: 0x005A3B49
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node20()
		{
			this.opl_p0 = 1607;
		}

		// Token: 0x060130FB RID: 78075 RVA: 0x005A575C File Offset: 0x005A3B5C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CB2D RID: 52013
		private int opl_p0;
	}
}
