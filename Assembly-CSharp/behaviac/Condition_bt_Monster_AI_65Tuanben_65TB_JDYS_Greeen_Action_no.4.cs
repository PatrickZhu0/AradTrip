using System;

namespace behaviac
{
	// Token: 0x02002BA3 RID: 11171
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_JDYS_Greeen_Action_node8 : Condition
	{
		// Token: 0x0601404F RID: 81999 RVA: 0x00603299 File Offset: 0x00601699
		public Condition_bt_Monster_AI_65Tuanben_65TB_JDYS_Greeen_Action_node8()
		{
			this.opl_p0 = 20775;
		}

		// Token: 0x06014050 RID: 82000 RVA: 0x006032AC File Offset: 0x006016AC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DA49 RID: 55881
		private int opl_p0;
	}
}
