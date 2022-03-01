using System;

namespace behaviac
{
	// Token: 0x020023F7 RID: 9207
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_normal_Action_node40 : Condition
	{
		// Token: 0x0601314D RID: 78157 RVA: 0x005A7FFF File Offset: 0x005A63FF
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_normal_Action_node40()
		{
			this.opl_p0 = 1512;
		}

		// Token: 0x0601314E RID: 78158 RVA: 0x005A8014 File Offset: 0x005A6414
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CB78 RID: 52088
		private int opl_p0;
	}
}
