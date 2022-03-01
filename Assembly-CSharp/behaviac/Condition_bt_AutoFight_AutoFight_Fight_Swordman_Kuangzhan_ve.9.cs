using System;

namespace behaviac
{
	// Token: 0x02002418 RID: 9240
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node21 : Condition
	{
		// Token: 0x0601318B RID: 78219 RVA: 0x005A9CD7 File Offset: 0x005A80D7
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node21()
		{
			this.opl_p0 = 1505;
		}

		// Token: 0x0601318C RID: 78220 RVA: 0x005A9CEC File Offset: 0x005A80EC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CBB6 RID: 52150
		private int opl_p0;
	}
}
