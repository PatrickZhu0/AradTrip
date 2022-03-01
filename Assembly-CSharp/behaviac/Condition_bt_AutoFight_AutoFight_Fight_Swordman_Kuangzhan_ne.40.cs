using System;

namespace behaviac
{
	// Token: 0x020023C6 RID: 9158
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node14 : Condition
	{
		// Token: 0x060130F2 RID: 78066 RVA: 0x005A5595 File Offset: 0x005A3995
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node14()
		{
			this.opl_p0 = 1608;
		}

		// Token: 0x060130F3 RID: 78067 RVA: 0x005A55A8 File Offset: 0x005A39A8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CB25 RID: 52005
		private int opl_p0;
	}
}
