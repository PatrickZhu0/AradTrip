using System;

namespace behaviac
{
	// Token: 0x020022C9 RID: 8905
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node40 : Condition
	{
		// Token: 0x06012F0D RID: 77581 RVA: 0x00597747 File Offset: 0x00595B47
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node40()
		{
			this.opl_p0 = 1514;
		}

		// Token: 0x06012F0E RID: 77582 RVA: 0x0059775C File Offset: 0x00595B5C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C920 RID: 51488
		private int opl_p0;
	}
}
