using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001DB9 RID: 7609
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Kuangzhan_Action_node17 : Action
	{
		// Token: 0x0601252B RID: 75051 RVA: 0x005596AC File Offset: 0x00557AAC
		public Action_bt_APC_APC_Kuangzhan_Action_node17()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 1;
			Input item = default(Input);
			item.delay = 0;
			item.moveInSkillState = false;
			item.moveKeepDistance = 0;
			item.PKRobotComboCheck = false;
			item.pressTime = 0;
			item.randomChangeDirection = false;
			item.skillID = 7107;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601252C RID: 75052 RVA: 0x0055973C File Offset: 0x00557B3C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF1D RID: 48925
		private List<Input> method_p0;

		// Token: 0x0400BF1E RID: 48926
		private bool method_p1;
	}
}
