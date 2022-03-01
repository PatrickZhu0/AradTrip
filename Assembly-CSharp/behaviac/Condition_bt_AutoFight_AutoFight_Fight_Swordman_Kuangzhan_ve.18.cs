using System;

namespace behaviac
{
	// Token: 0x02002427 RID: 9255
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node75 : Condition
	{
		// Token: 0x060131A6 RID: 78246 RVA: 0x005AA27B File Offset: 0x005A867B
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node75()
		{
			this.opl_p0 = 1514;
		}

		// Token: 0x060131A7 RID: 78247 RVA: 0x005AA290 File Offset: 0x005A8690
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CBCE RID: 52174
		private int opl_p0;
	}
}
