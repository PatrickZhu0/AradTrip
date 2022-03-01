using System;

namespace behaviac
{
	// Token: 0x0200239E RID: 9118
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node42 : Condition
	{
		// Token: 0x060130A2 RID: 77986 RVA: 0x005A29FF File Offset: 0x005A0DFF
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node42()
		{
			this.opl_p0 = 1622;
		}

		// Token: 0x060130A3 RID: 77987 RVA: 0x005A2A14 File Offset: 0x005A0E14
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CAC7 RID: 51911
		private int opl_p0;
	}
}
