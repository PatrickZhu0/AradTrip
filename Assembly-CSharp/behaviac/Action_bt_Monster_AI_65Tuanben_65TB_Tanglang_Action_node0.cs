using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002C8B RID: 11403
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Action_node0 : Action
	{
		// Token: 0x0601420D RID: 82445 RVA: 0x0060B990 File Offset: 0x00609D90
		public Action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Action_node0()
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
			item.skillID = 20750;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601420E RID: 82446 RVA: 0x0060BA20 File Offset: 0x00609E20
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DBCB RID: 56267
		private List<Input> method_p0;

		// Token: 0x0400DBCC RID: 56268
		private bool method_p1;
	}
}
