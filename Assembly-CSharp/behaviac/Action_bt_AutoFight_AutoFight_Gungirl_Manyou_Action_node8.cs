using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020024D7 RID: 9431
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node8 : Action
	{
		// Token: 0x060132F8 RID: 78584 RVA: 0x005B253C File Offset: 0x005B093C
		public Action_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node8()
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
			item.skillID = 2518;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060132F9 RID: 78585 RVA: 0x005B25CC File Offset: 0x005B09CC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CD15 RID: 52501
		private List<Input> method_p0;

		// Token: 0x0400CD16 RID: 52502
		private bool method_p1;
	}
}
