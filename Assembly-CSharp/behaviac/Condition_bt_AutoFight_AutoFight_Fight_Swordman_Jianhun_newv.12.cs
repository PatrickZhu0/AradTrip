using System;

namespace behaviac
{
	// Token: 0x020022BD RID: 8893
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node5 : Condition
	{
		// Token: 0x06012EF5 RID: 77557 RVA: 0x00596607 File Offset: 0x00594A07
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node5()
		{
			this.opl_p0 = 1514;
		}

		// Token: 0x06012EF6 RID: 77558 RVA: 0x0059661C File Offset: 0x00594A1C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C908 RID: 51464
		private int opl_p0;
	}
}
