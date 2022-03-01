using System;

namespace behaviac
{
	// Token: 0x02002D61 RID: 11617
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node19 : Condition
	{
		// Token: 0x060143A5 RID: 82853 RVA: 0x006137BF File Offset: 0x00611BBF
		public Condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node19()
		{
			this.opl_p0 = 21882;
		}

		// Token: 0x060143A6 RID: 82854 RVA: 0x006137D4 File Offset: 0x00611BD4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DD71 RID: 56689
		private int opl_p0;
	}
}
