using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200262C RID: 9772
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node83 : Action
	{
		// Token: 0x0601359E RID: 79262 RVA: 0x005C187C File Offset: 0x005BFC7C
		public Action_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node83()
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
			item.skillID = 1011;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601359F RID: 79263 RVA: 0x005C190C File Offset: 0x005BFD0C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CFEC RID: 53228
		private List<Input> method_p0;

		// Token: 0x0400CFED RID: 53229
		private bool method_p1;
	}
}
