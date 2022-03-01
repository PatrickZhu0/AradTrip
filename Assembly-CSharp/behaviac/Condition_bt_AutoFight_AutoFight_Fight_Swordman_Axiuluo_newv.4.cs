using System;

namespace behaviac
{
	// Token: 0x02002207 RID: 8711
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node9 : Condition
	{
		// Token: 0x06012D98 RID: 77208 RVA: 0x0058CC29 File Offset: 0x0058B029
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node9()
		{
			this.opl_p0 = 1710;
		}

		// Token: 0x06012D99 RID: 77209 RVA: 0x0058CC3C File Offset: 0x0058B03C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C787 RID: 51079
		private int opl_p0;
	}
}
