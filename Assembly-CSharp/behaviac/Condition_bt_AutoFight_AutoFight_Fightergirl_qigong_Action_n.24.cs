using System;

namespace behaviac
{
	// Token: 0x02001F11 RID: 7953
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node32 : Condition
	{
		// Token: 0x060127C6 RID: 75718 RVA: 0x00568723 File Offset: 0x00566B23
		public Condition_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node32()
		{
			this.opl_p0 = 3008;
		}

		// Token: 0x060127C7 RID: 75719 RVA: 0x00568738 File Offset: 0x00566B38
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C1BC RID: 49596
		private int opl_p0;
	}
}
