using System;

namespace behaviac
{
	// Token: 0x02002345 RID: 9029
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node27 : Condition
	{
		// Token: 0x06012FF8 RID: 77816 RVA: 0x0059E613 File Offset: 0x0059CA13
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node27()
		{
			this.opl_p0 = 1514;
		}

		// Token: 0x06012FF9 RID: 77817 RVA: 0x0059E628 File Offset: 0x0059CA28
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CA0F RID: 51727
		private int opl_p0;
	}
}
