using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020032AA RID: 12970
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GHFB_dalishi1_node5 : Action
	{
		// Token: 0x06014DCA RID: 85450 RVA: 0x00648B44 File Offset: 0x00646F44
		public Action_bt_Monster_AI_GHFB_dalishi1_node5()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 100000;
			this.method_p1 = 100000;
			this.method_p2 = 100000;
			this.method_p3 = 100000;
			this.method_p4 = new List<int>();
			this.method_p4.Capacity = 1;
			int item = 70220011;
			this.method_p4.Add(item);
			this.method_p5 = false;
		}

		// Token: 0x06014DCB RID: 85451 RVA: 0x00648BBA File Offset: 0x00646FBA
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_MonsterNumberOfInAreaByCamp(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4, this.method_p5);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E6B7 RID: 59063
		private int method_p0;

		// Token: 0x0400E6B8 RID: 59064
		private int method_p1;

		// Token: 0x0400E6B9 RID: 59065
		private int method_p2;

		// Token: 0x0400E6BA RID: 59066
		private int method_p3;

		// Token: 0x0400E6BB RID: 59067
		private List<int> method_p4;

		// Token: 0x0400E6BC RID: 59068
		private bool method_p5;
	}
}
