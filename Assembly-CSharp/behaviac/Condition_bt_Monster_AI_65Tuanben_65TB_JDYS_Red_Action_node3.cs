using System;

namespace behaviac
{
	// Token: 0x02002BAC RID: 11180
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_JDYS_Red_Action_node3 : Condition
	{
		// Token: 0x0601405F RID: 82015 RVA: 0x0060392E File Offset: 0x00601D2E
		public Condition_bt_Monster_AI_65Tuanben_65TB_JDYS_Red_Action_node3()
		{
			this.opl_p0 = 20000;
			this.opl_p1 = true;
			this.opl_p2 = false;
		}

		// Token: 0x06014060 RID: 82016 RVA: 0x00603950 File Offset: 0x00601D50
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsAroundHorizontalEdge(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DA57 RID: 55895
		private int opl_p0;

		// Token: 0x0400DA58 RID: 55896
		private bool opl_p1;

		// Token: 0x0400DA59 RID: 55897
		private bool opl_p2;
	}
}
