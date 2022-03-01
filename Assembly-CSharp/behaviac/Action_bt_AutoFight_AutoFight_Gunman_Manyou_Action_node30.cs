using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200260A RID: 9738
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node30 : Action
	{
		// Token: 0x0601355A RID: 79194 RVA: 0x005C08EC File Offset: 0x005BECEC
		public Action_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node30()
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
			item.skillID = 1104;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601355B RID: 79195 RVA: 0x005C097C File Offset: 0x005BED7C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CFA6 RID: 53158
		private List<Input> method_p0;

		// Token: 0x0400CFA7 RID: 53159
		private bool method_p1;
	}
}
