using System;

namespace behaviac
{
	// Token: 0x020023FB RID: 9211
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_normal_Action_node45 : Condition
	{
		// Token: 0x06013155 RID: 78165 RVA: 0x005A81B5 File Offset: 0x005A65B5
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_normal_Action_node45()
		{
			this.opl_p0 = 1604;
		}

		// Token: 0x06013156 RID: 78166 RVA: 0x005A81C8 File Offset: 0x005A65C8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CB80 RID: 52096
		private int opl_p0;
	}
}
