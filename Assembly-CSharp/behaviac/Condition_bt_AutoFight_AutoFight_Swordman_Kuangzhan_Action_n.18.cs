using System;

namespace behaviac
{
	// Token: 0x02002959 RID: 10585
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node59 : Condition
	{
		// Token: 0x06013BE7 RID: 80871 RVA: 0x005E7423 File Offset: 0x005E5823
		public Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node59()
		{
			this.opl_p0 = 1605;
		}

		// Token: 0x06013BE8 RID: 80872 RVA: 0x005E7438 File Offset: 0x005E5838
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D64D RID: 54861
		private int opl_p0;
	}
}
