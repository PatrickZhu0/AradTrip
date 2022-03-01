using System;

namespace behaviac
{
	// Token: 0x020023D8 RID: 9176
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node11 : Condition
	{
		// Token: 0x06013115 RID: 78101 RVA: 0x005A7067 File Offset: 0x005A5467
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node11()
		{
			this.opl_p0 = 10001;
		}

		// Token: 0x06013116 RID: 78102 RVA: 0x005A707C File Offset: 0x005A547C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CB44 RID: 52036
		private int opl_p0;
	}
}
