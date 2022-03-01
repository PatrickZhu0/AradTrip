using System;

namespace behaviac
{
	// Token: 0x02002BAD RID: 11181
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_JDYS_Red_Action_node0 : Condition
	{
		// Token: 0x06014061 RID: 82017 RVA: 0x0060398F File Offset: 0x00601D8F
		public Condition_bt_Monster_AI_65Tuanben_65TB_JDYS_Red_Action_node0()
		{
			this.opl_p0 = 20774;
		}

		// Token: 0x06014062 RID: 82018 RVA: 0x006039A4 File Offset: 0x00601DA4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DA5A RID: 55898
		private int opl_p0;
	}
}
